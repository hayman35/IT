using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explisionVFX;
    public float expolsionForce = 10f;
    public float radius = 10f;
    public AudioSource expolsionSound;
    public LayerMask mask;
    public ITManager it;

    private void Start() 
    {
    }
    private void Update() 
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        Explode();
        Destroy(gameObject);
        if((mask.value & 1<<c.gameObject.layer) == 1<<c.gameObject.layer)
        {
            if(c.collider.tag == "Player")
            {it.hit_Player = true;}
            if(c.collider.tag == "Enemy")
            {it.hit_Enemy = true;}
        }
        
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

        GameObject VFX = Instantiate(explisionVFX,transform.position, transform.rotation);
        expolsionSound.Play();
        Destroy(VFX,2f);
    }

     
}
