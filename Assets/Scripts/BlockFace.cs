using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFace : MonoBehaviour
{
    public GameObject BlockFaceObject;

    // Start is called before the first frame update
    void Start()
    {
        if (!Physics.Raycast(transform.position - transform.up * 0.01f, transform.up, out RaycastHit hit, 3))
        {
            Instantiate(BlockFaceObject, transform.position, transform.rotation, transform);
        }
    }
}
