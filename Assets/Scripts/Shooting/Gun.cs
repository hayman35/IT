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

    [SerializeField]
    private ParticleSystem muzzleParticle;

    private float timer;
    
    [SerializeField]
    private Transform firePoint;

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
        muzzleParticle.Play();
        gunfireSource.Play();
        // Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 19f);

        muzzleParticle.Play();
        Ray ray = new Ray(firePoint.position,firePoint.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
                //Destroy(hit.collider.gameObject);
        }
    }
}
