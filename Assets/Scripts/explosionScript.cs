using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    float currentSize;

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(3 * Time.deltaTime, 3 * Time.deltaTime, transform.position.z);
        if(transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}