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


    // Start is called before the first frame update
    void Start()
    {
        gun = transform.GetChild(0);
        cam = GetComponentInChildren<Camera>();
        normalFieldOfView = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting
        shotTimer += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") == 1 && shotTimer > TimeBetweenShots)
        {
            Shoot();
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


        float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;
        transform.Rotate(Vector3.up, mouseX, Space.World);
        transform.Rotate(Vector3.left, mouseY, Space.Self);

        //Clamp the rotation so the turret can't look too far up or down
        if (transform.localEulerAngles.x < 20)
        {
            transform.localEulerAngles = new Vector3(20, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }

    void Shoot()
    {
        shotTimer = 0;
        GameObject bullet = Instantiate(BulletPrefab, gun.position, transform.rotation);
        bullet.GetComponent<Bullet>().Damage = BulletDamage;
        AudioSource.PlayClipAtPoint(ShootSound, gun.position);
    }
}
