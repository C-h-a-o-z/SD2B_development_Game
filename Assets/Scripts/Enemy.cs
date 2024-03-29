using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    float dirX = 1;
    public float hp = 2;
    bool isAlive = true;
    public float startingDir = 1;
    private GameObject scoreCounter;
    public AudioSource deathSound;
    Vector2 startloc;


    Animator anim;
    //root motion for animation
    //get animation from ch
    private void Start()
    {
        dirX = startingDir;
        anim = GetComponentInChildren<Animator>();
        scoreCounter = GameObject.Find("Player");
        startloc = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {

            transform.Translate(transform.right * dirX * speed * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

            Debug.DrawRay(transform.position, transform.right * 0.6f * dirX, Color.blue);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hit.collider.GetComponent<playerMovement>().LoseSceneLoad();
                }
                else if (hit.collider.CompareTag("Obstacle"))
                {
                    dirX = dirX * -1;
                }
            }
        }
    }
    public void takeDamage()
    {
        --hp;
        if (hp <= 0)
        {
            die();
        }

    }
    void die()
    {
        deathSound.Play();
        scoreCounter.GetComponent<Score>().scoreAdd();
        isAlive = false;
        anim.SetBool("IsAlive", isAlive);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Destroy(gameObject, 1.5f);
    }

    public void OutWorld()
    {
        transform.position = startloc;
        dirX = startingDir;
    }
}
