using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFaceClickArea : MonoBehaviour
{
    public GameObject Block;
    public GameObject Turret;

    void OnMouseOver()
    {
        //Right Click
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(Turret, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    //Left Click
    void OnMouseDown()
    {
        Instantiate(Block, transform.position + transform.up * 1.5f, Quaternion.identity);
        Destroy(gameObject);
    }
}
