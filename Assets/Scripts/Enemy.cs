using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    public AudioMixerSnapshot MovingUp, MovingDown;
    public float SnapshotTransitionTime = 0.1f;

    //Hover Movement
    public float HoverAmplitude = 1f;
    float sineOffset;

    //Target
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        mat = GetComponent<MeshRenderer>().material;
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        hitTimer = HitDuration;
        sineOffset = Random.Range(0, 2 * Mathf.PI);
        target = GameObject.Find("Enemy Target Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (hitTimer < HitDuration)
        {
            hitTimer += Time.deltaTime;
            mat.color = Color.Lerp(HitColor, Color.white, hitTimer / HitDuration);
        }

        //Hover
        float y = transform.position.y + HoverAmplitude * Mathf.Sin(sineOffset + Time.time) * Time.deltaTime;
        if (Mathf.Cos(sineOffset + Time.time) > 0)
        {
            MovingUp.TransitionTo(SnapshotTransitionTime);
        }
        else
        {
            MovingDown.TransitionTo(SnapshotTransitionTime);
        }
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

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
