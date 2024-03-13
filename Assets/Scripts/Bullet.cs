using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Speed = 20f;
    public float ExistenceTime = 3f;
    float timeSinceCreation = 0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * Speed;
    }

    //Forward direction for bullet is transform.up

    // Update is called once per frame
    void Update()
    {
        timeSinceCreation += Time.deltaTime;
        if (timeSinceCreation > ExistenceTime)
        {
            Destroy(gameObject);
        }

    }
}
