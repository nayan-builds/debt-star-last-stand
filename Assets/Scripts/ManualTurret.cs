using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTurret : Shooting
{
    public float Sensitivity = 2f;
    Transform gun;

    //Camera Zoom
    Camera cam;
    public float ZoomFieldOfView = 30f;
    float normalFieldOfView;
    public float TimeToZoom = 0.25f;
    float zoomTimer = 0f;
    float xRotation = 0f;
    float yRotation = -90f;


    // Start is called before the first frame update
    void Start()
    {
        gun = transform.GetChild(0);
        cam = GetComponentInChildren<Camera>();
        normalFieldOfView = cam.fieldOfView;
        Debug.Log(transform.rotation.eulerAngles.x);
        Debug.Log(transform.rotation.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting
        shotTimer += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") == 1 && shotTimer > TimeBetweenShots)
        {
            Shoot(gun.position, transform.rotation);
        }

        //Zoom on Right Click
        if (Input.GetAxisRaw("Fire2") == 1)
        {
            zoomTimer += Time.deltaTime;
            if (zoomTimer > TimeToZoom) zoomTimer = TimeToZoom;
            cam.fieldOfView = Mathf.Lerp(normalFieldOfView, ZoomFieldOfView, zoomTimer / TimeToZoom);
        }
        else
        {
            zoomTimer -= Time.deltaTime;
            if (zoomTimer < 0) zoomTimer = 0;
            cam.fieldOfView = Mathf.Lerp(normalFieldOfView, ZoomFieldOfView, zoomTimer / TimeToZoom);
        }

        //Rotation w/ clamping from 
        //https://forum.unity.com/threads/solved-how-to-clamp-camera-rotation-on-the-x-axis-fps-controller.526871/
        xRotation += Input.GetAxis("Mouse X") * Sensitivity;
        yRotation += Input.GetAxis("Mouse Y") * Sensitivity;

        yRotation = Mathf.Clamp(yRotation, -160f, -20f);
        transform.rotation = Quaternion.Euler(-yRotation, xRotation, 0f);
    }
}
