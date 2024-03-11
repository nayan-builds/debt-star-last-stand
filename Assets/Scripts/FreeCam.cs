using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float Speed = 10f;
    public float UpSpeed = 10f;
    public float Sensitivity = 2f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Update()
    {

        //Rotation w/ clamping from 
        //https://forum.unity.com/threads/solved-how-to-clamp-camera-rotation-on-the-x-axis-fps-controller.526871/

        xRotation += Input.GetAxis("Mouse X") * Sensitivity;
        yRotation += Input.GetAxis("Mouse Y") * Sensitivity;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(-yRotation, xRotation, 0f);


        float forward = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");
        float up = Input.GetAxis("Jump");
        Vector3 movement = transform.forward * forward + transform.right * strafe;
        movement = movement.normalized;

        transform.position += movement * Time.deltaTime * Speed;
        transform.position += transform.up * up * Time.deltaTime * UpSpeed;
    }
}
