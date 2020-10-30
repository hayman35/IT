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

    public Transform firePoint;
    public float rocketSpeed = 10f;
    private float timer;
    public Animator animator;
    public GameObject rocket;
    bool launched;
   
    [SerializeField]
    public AudioSource rocketSound;

    private void Start() 
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if(Input.GetButton("Fire1"))
            {   
                rocketSound.Play();
                animator.SetTrigger("shoot");
                Camera cam = Camera.main;
                GameObject rocketGO = (GameObject)Instantiate(rocket,cam.transform.position, firePoint.transform.rotation);
                rocketGO.SetActive(true);
                rocketGO.GetComponent<Rigidbody>().AddForce(cam.transform.forward * rocketSpeed,ForceMode.Impulse);
                timer = 0f;
            }
        }

    }


  
}
