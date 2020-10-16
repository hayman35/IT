using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,1.5f)]
    private float fireRate = 0.3f;

    [SerializeField]
    [Range(1,10)]
    private int damage = 1;

    public GameObject firePoint;

    public ParticleSystem muzzleFlash;

    public float bulletSpeed = 100f;

    public GameObject impactFX;

    private float timer;

    public GameObject bullet;

    [SerializeField]
    private AudioSource gunfireSource;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
                
            }
        }

    }

    private void FireGun()
    {
        //muzzleFlash.Play();
        gunfireSource.Play();
       
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f); // getting a vector thats cener screen 
        RaycastHit hit;        
        if(Physics.Raycast(ray, out hit, 200))
        {

        }

        GameObject impactGO = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO,2f);
    }
}
