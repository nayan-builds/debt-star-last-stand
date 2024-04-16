using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFaceClickArea : MonoBehaviour
{
    ShopController shop;

    void Start()
    {
        shop = GameObject.Find("Controller").GetComponent<ShopController>();
    }

    //Left Click
    void OnMouseDown()
    {
        if (shop.Build(transform.position, transform.up, transform.rotation))
            Destroy(gameObject);
    }
}
