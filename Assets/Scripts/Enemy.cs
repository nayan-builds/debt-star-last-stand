using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Health
    public float MAX_HEALTH = 100f;
    float health;

    //Hit Color Change
    public Color HitColor = Color.red;
    public float HitDuration = 0.5f;
    float hitTimer;
    Material mat;





    public Transform Tower;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
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
            hitTimer = 0f;
        }
    }
}
