using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    //Health
    public float MAX_HEALTH = 100f;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.tag == "Enemy Bullet")
        {
            health -= co.GetComponent<Bullet>().Damage;
            if (health <= 0)
            {
                //Game Over
            }
        }
    }
}
