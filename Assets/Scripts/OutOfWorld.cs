using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("enemyoutworld");
            collision.GetComponent<Enemy>().OutWorld();
        }

        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<playerMovement>().LoseSceneLoad();
        }
    }
}
