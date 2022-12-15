using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	[SerializeField] private LayerMask m_WhatIsGround;
	[SerializeField] private Transform groundCheck;
	public bool onGround = false;

	public float speed = 10;
    public float jumpForce = 100;
	const float k_GroundedRadius = .2f;
	public int jumpAmount = 1;
	private Rigidbody2D rigBody2D;
	private float facing = 1;
	public GameObject bullet;

    private void Awake()
    {
		rigBody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {


		if (Input.GetKeyDown(KeyCode.Y))
        {
			if (onGround == true)
			{
				onGround = false;
				rigBody2D.AddForce(new Vector2(0f, jumpForce));
			}
			else if (jumpAmount > 0)
			{
				jumpAmount = jumpAmount - 1;
				rigBody2D.velocity = new Vector2(rigBody2D.velocity.x, 0);
				rigBody2D.AddForce(new Vector2(0f, jumpForce));
			}
			else
            {
				Debug.Log("NoRemainingJumps");
            }

			}


			

        
		if (Input.GetKeyDown(KeyCode.X))
        {
			GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
			spawnedBullet.GetComponent<bulletScript>().direction = facing;
			spawnedBullet.transform.position = new Vector2(spawnedBullet.transform.position.x + facing, spawnedBullet.transform.position.y);
        }

    }
	private void FixedUpdate()
	{
		float dirX = Input.GetAxisRaw("Horizontal");
		transform.Translate(transform.right * dirX * speed * Time.deltaTime);

		if (dirX < 0 || dirX > 0)
		{
			facing = dirX;
		}

		bool wasGrounded = onGround;
		onGround = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				onGround = true;
				jumpAmount = 1;
			}
		}
	}
}
