using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Transform Camera;
    Transform greenHealthBar;
    Transform redHealthBar;

    void Start()
    {
        Camera = GameObject.Find("Turret Camera").transform;
        greenHealthBar = transform.GetChild(0);
        redHealthBar = transform.GetChild(1);
    }
    void Update()
    {
        transform.LookAt(Camera);

        // Keep the red health bar slightly behind the green health bar
        redHealthBar.position = greenHealthBar.position + Camera.forward * 0.001f;
    }

    public void SetHealth(float health)
    {
        greenHealthBar.localScale = new Vector3(greenHealthBar.localScale.x, health, greenHealthBar.localScale.z);
    }
}
