using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explisionVFX;
    public float expolsionForce = 10f;
    public float radius = 10f;


    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }


    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if(rig != null)
            {rig.AddExplosionForce(expolsionForce,transform.position, radius, 1f, ForceMode.Impulse);}
        }

        Instantiate(explisionVFX,transform.position, transform.rotation);
        Destroy(gameObject,2f);
    }

     
}
