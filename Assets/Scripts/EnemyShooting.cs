using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{

    // Update is called once per frame
    void Update()
    {
        //Shooting
        shotTimer += Time.deltaTime;
        if (shotTimer > TimeBetweenShots)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Quaternion rot = Quaternion.LookRotation(-transform.up, transform.forward);
        Shoot(transform.position, rot);
    }
}
