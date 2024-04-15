using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFaceClickArea : MonoBehaviour
{
    public GameObject Block;
    public GameObject Turret;
    GamePhaseController controller;

    void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<GamePhaseController>();
    }

    //Left Click
    void OnMouseDown()
    {
        switch (controller.SelectedBuildable)
        {
            case Buildable.Block:
                Instantiate(Block, transform.position + transform.up * 1.5f, Quaternion.identity);
                break;
            case Buildable.Turret:
                Instantiate(Turret, transform.position, transform.rotation);
                break;
        }
        Destroy(gameObject);
    }
}
