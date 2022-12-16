using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
	[SerializeField] private LayerMask m_WhatIsGround;
	[SerializeField] private Transform groundCheck;
	public bool onGround = false;
	public AudioSource regShot;
	public AudioSource rpgShot;

	public float speed = 10;
    public float jumpForce = 100;
	const float k_GroundedRadius = .2f;
	public int jumpAmount = 1;
	private Rigidbody2D rigBody2D;
	private float facing = 1;
	public GameObject bullet;
	public GameObject explodingBullet;
	public bool explodingBulletActive = false;
	public float maxRegCooldown = 3;
	public float maxExplodeCooldown = 8;
	float regCooldown;
	float explodeCooldown;
	public GameObject regWeapon;
	public GameObject RpgWeapon;


	private void Awake()
    {
		rigBody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
		if (regCooldown >= 0)
        {
			regCooldown = regCooldown - 1 * Time.deltaTime;
        }
		if (explodeCooldown >= 0)
		{
			explodeCooldown = explodeCooldown - 1 * Time.deltaTime;
		}





		if (Input.GetKeyDown(KeyCode.Space))
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

		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
			explodingBulletActive = !explodingBulletActive;
        }
			
		if (explodingBulletActive)
        {
			regWeapon.GetComponent<SpriteRenderer>().enabled = false;
			RpgWeapon.GetComponent<SpriteRenderer>().enabled = true;
		}
		else if (!explodingBulletActive)
        {
			regWeapon.GetComponent<SpriteRenderer>().enabled = true;
			RpgWeapon.GetComponent<SpriteRenderer>().enabled = false;
		}


        
		if (Input.GetKeyDown(KeyCode.R))
        {
			if (!explodingBulletActive && regCooldown <= 0)
            {
				regShot.Play();
				GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
				spawnedBullet.GetComponent<bulletScript>().direction = facing;
				regCooldown = maxRegCooldown;
			}
			else if (explodingBulletActive && explodeCooldown <= 0)
            {
				rpgShot.Play();
				GameObject spawnedBullet = Instantiate(explodingBullet, transform.position, Quaternion.identity);
				spawnedBullet.GetComponent<bulletScript>().direction = facing;
				explodeCooldown = maxExplodeCooldown;
			}

			//spawnedBullet.transform.position = new Vector2(spawnedBullet.transform.position.x + facing, spawnedBullet.transform.position.y);
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

		

		if (dirX < 0)
		{
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
			regWeapon.GetComponent<SpriteRenderer>().flipX = true;
			regWeapon.transform.position = new Vector2(gameObject.transform.position.x + -0.65f, regWeapon.transform.position.y);
			RpgWeapon.GetComponent<SpriteRenderer>().flipX = true;
			RpgWeapon.transform.position = new Vector2(gameObject.transform.position.x + -0.6f, RpgWeapon.transform.position.y);

		}
		else if (dirX > 0)
        {
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
			regWeapon.GetComponent<SpriteRenderer>().flipX = false;
			regWeapon.transform.position = new Vector2(gameObject.transform.position.x + 0.65f, regWeapon.transform.position.y);
			RpgWeapon.GetComponent<SpriteRenderer>().flipX = false;
			RpgWeapon.transform.position = new Vector2(gameObject.transform.position.x + 0.6f, RpgWeapon.transform.position.y);
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
	public void LoseSceneLoad()
	{
		SceneManager.LoadScene("LoseScreen");
	}
	public void WinSceneLoad()
	{
		SceneManager.LoadScene("WinScreen");
	}
}
