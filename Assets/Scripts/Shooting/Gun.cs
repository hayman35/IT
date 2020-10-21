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

    public GameObject muzzleFlash;

    public float bulletSpeed = 100f;

    public GameObject impactFX;
 
    private float timer;

    public float weaponRange = 200f;

    public GameObject bulletFX;

    public GameObject flare;

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
        gunfireSource.Play();
       
        //Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f); // getting a vector thats cener screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        RaycastHit hit;        
    
    
        if(Physics.Raycast(ray, out hit, weaponRange))
        {
            // take the point of collision (make sure all objects have a collider)
            Vector3 colisionPoint = hit.point;

             //Create a vector for the path of the bullet from the 'gun' to the target
            Vector3 bulletVector = colisionPoint - bulletFX.transform.position;

            GameObject bulletGO = Instantiate(bulletFX, firePoint.transform.position, Quaternion.LookRotation(ray.direction));
            bulletGO.GetComponent<Rigidbody>().AddForce(ray.direction * bulletSpeed, ForceMode.VelocityChange);
            Destroy(bulletGO,4f);
            GameObject impactGO = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,2f);

            // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce (-hit.normal * 200f);
                }
        }
        
        GameObject muzzleFlashGO = Instantiate(muzzleFlash, flare.transform.position, flare.transform.rotation);
        Destroy(muzzleFlashGO, 2f);
    }
}
