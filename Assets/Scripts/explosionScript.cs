using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    float currentSize;

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(5 * Time.deltaTime, 5 * Time.deltaTime, transform.position.z);
        if(transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().hp = 0;
            collision.GetComponent<Enemy>().takeDamage();
        }
        else if(collision.CompareTag("Player"))
        {
            collision.GetComponent<playerMovement>().LoseSceneLoad();
        }
    }
}
