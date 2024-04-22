using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Shooting
{
    public float range;
    Transform gun;
    SphereCollider rangeCollider;
    List<Transform> enemiesInRange = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        gun = transform.GetChild(0);
        rangeCollider = GetComponent<SphereCollider>();
        rangeCollider.radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        //Remove destroyed enemies from the list
        enemiesInRange.RemoveAll(enemy => enemy == null);
        if (enemiesInRange.Count > 0)
        {
            enemiesInRange.Sort((a, b) => Vector3.SqrMagnitude(a.position - transform.position).CompareTo(Vector3.SqrMagnitude(b.position - transform.position)));
            Transform target = enemiesInRange[0];
            transform.LookAt(target);
            if (shotTimer > TimeBetweenShots)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        shotTimer = 0;
        Quaternion rot = Quaternion.LookRotation(-transform.up, transform.forward);
        GameObject bullet = Instantiate(BulletPrefab, gun.position, rot);
        bullet.GetComponent<Bullet>().Damage = BulletDamage;
        AudioSource.PlayClipAtPoint(ShootSound, gun.position);
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.CompareTag("Enemy"))
        {
            enemiesInRange.Add(co.transform);
        }
    }

    void OnTriggerExit(Collider co)
    {
        if (co.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(co.transform);
        }
    }
}
