using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    //Health
    public float MAX_HEALTH = 100f;
    float health;
    public Gradient HealthBarGradient;
    public Slider HealthBar;
    Image healthBarFill;
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        HealthBar.minValue = 0;
        HealthBar.maxValue = MAX_HEALTH;
        healthBarFill = HealthBar.fillRect.GetComponent<Image>();
        HealthBar.value = health;
        healthBarFill.color = HealthBarGradient.Evaluate(1);
    }

    void OnTriggerEnter(Collider co)
    {
        if (co.CompareTag("EnemyProjectile"))
        {
            health -= co.GetComponent<Bullet>().Damage;
            HealthBar.value = health;
            healthBarFill.color = HealthBarGradient.Evaluate(health / MAX_HEALTH);
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
