using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletDamage = 3f;
    public float TimeBetweenShots = 0.1f;
    float shotTimer = 0f;
    public AudioClip ShootSound;


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
        shotTimer = 0;
        Quaternion rot = Quaternion.LookRotation(-transform.up, transform.forward);
        GameObject bullet = Instantiate(BulletPrefab, transform.position, rot);
        bullet.GetComponent<Bullet>().Damage = BulletDamage;
        AudioSource.PlayClipAtPoint(ShootSound, transform.position);
    }
}
