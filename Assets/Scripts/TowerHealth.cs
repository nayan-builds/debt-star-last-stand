using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    //Health
    public float MAX_HEALTH = 100f;
    float health;
    public Gradient healthBarGradient;
    public Slider healthBar;
    Image healthBarFill;
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        healthBar.minValue = 0;
        healthBar.maxValue = MAX_HEALTH;
        healthBarFill = healthBar.fillRect.GetComponent<Image>();
        healthBar.value = health;
        healthBarFill.color = healthBarGradient.Evaluate(1);
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.tag == "EnemyProjectile")
        {
            health -= co.GetComponent<Bullet>().Damage;
            healthBar.value = health;
            healthBarFill.color = healthBarGradient.Evaluate(health / MAX_HEALTH);
            if (health <= 0)
            {
                //Game Over
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                GameOverScreen.SetActive(true);
            }
        }
    }
}
