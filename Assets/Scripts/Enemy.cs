using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Health
    public float MAX_HEALTH = 100f;
    float health;
    EnemyHealthBar healthBar;

    //Hit Color Change
    public Color HitColor = Color.red;
    public float HitDuration = 0.5f;
    float hitTimer;
    Material mat;

    //Audio
    public List<AudioClip> DeathSounds;





    public Transform Tower;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        mat = GetComponent<MeshRenderer>().material;
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        hitTimer = HitDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTimer < HitDuration)
        {
            hitTimer += Time.deltaTime;
            mat.color = Color.Lerp(HitColor, Color.white, hitTimer / HitDuration);
        }
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "Projectile")
        {
            health -= co.gameObject.GetComponent<Bullet>().Damage;
            healthBar.SetHealth(health / MAX_HEALTH);
            if (health <= 0)
            {
                Die();
            }
            hitTimer = 0f;
        }
    }

    void Die()
    {
        AudioClip DeathSound = DeathSounds[Random.Range(0, DeathSounds.Count)];
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Destroy(gameObject);
    }
}
