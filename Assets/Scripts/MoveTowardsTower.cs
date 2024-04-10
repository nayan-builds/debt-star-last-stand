using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTower : MonoBehaviour
{
    public float Speed = 5f;
    Transform Tower;
    // Start is called before the first frame update
    void Start()
    {
        Tower = GameObject.Find("Enemy Target Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.MoveTowards(transform.position, Tower.position, Speed * Time.deltaTime) - transform.position;
    }

    void OnTriggerEnter(Collider co)
    {
        Debug.Log(co.name);
        if (co.name == "Enemy Range")
        {
            gameObject.GetComponent<EnemyShooting>().enabled = true;
            Destroy(this);
        }
    }
}
