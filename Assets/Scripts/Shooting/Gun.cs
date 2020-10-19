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

    public GameObject muzzlePosition;

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
       
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f); // getting a vector thats cener screen
        
        RaycastHit hit;        
    
    
        if(Physics.Raycast(ray, out hit, weaponRange))
        {

            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("HIT");
            }

            // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce (-hit.normal * 200f);
                }
        }
        
        GameObject muzzleFlashGO = Instantiate(muzzleFlash, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
        GameObject bulletGO = Instantiate(bulletFX, firePoint.transform.position, Quaternion.LookRotation(ray.direction));
        bulletGO.GetComponent<Rigidbody>().AddForce(ray.direction * bulletSpeed, ForceMode.VelocityChange); 
        float Dis = bulletGO.GetComponent<Rigidbody>().velocity * Time.deltaTime;

        GameObject impactGO = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO,2f);
        
        
            
        
        Destroy(bulletGO,4f);
        Destroy(muzzleFlashGO, 2f);
    }
}
