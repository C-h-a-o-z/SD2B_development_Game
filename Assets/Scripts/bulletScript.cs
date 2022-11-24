using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float lifeTime = 3;
    public float bulletSpeed = 15;
    public float direction = 1;
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
}
