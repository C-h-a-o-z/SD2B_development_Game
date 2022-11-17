using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool onGround = false;
    public LayerMask ground;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(ground.value);
        if (collision.gameObject.layer == ground)
        {
            Debug.Log("wowwww");
                onGround = true; 
        }
    }
}
