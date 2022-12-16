using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float lifeTime = 3;
    public float bulletSpeed = 15;
    public float direction = 1;
    public bool exploding;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * direction * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (exploding == true)
            {
                Debug.Log("boom");
                GameObject spawnExplosion = Instantiate(explosion, transform.position, Quaternion.identity);

            }
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().takeDamage();
            }
            Destroy(gameObject);
        }
        //USE CIRCLE COLLIDERSSSSSS 
    }
}
