using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Transform Camera;
    Transform greenHealthBar;

    void Start()
    {
        Camera = GameObject.Find("Turret Camera").transform;
        greenHealthBar = transform.GetChild(0);
    }
    void Update()
    {
        transform.LookAt(Camera);
    }

    public void SetHealth(float health)
    {
        greenHealthBar.localScale = new Vector3(greenHealthBar.localScale.x, health * 2, greenHealthBar.localScale.z);
    }
}
