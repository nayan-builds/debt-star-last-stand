using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for anything shooting
public abstract class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletDamage = 10f;
    public float TimeBetweenShots = 2f;
    protected float shotTimer = 0f;
    public AudioClip ShootSound;

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        shotTimer = 0;
        GameObject bullet = Instantiate(BulletPrefab, position, rotation);
        bullet.GetComponent<Bullet>().Damage = BulletDamage;
        AudioSource.PlayClipAtPoint(ShootSound, position);
    }
}
