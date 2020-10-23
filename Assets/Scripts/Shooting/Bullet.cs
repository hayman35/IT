using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;
    Vector3 mPresPos;


    // Start is called before the first frame update
    void Start()
    {
        mPresPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        mPresPos = transform.position;
        RaycastHit[] hits = Physics.RaycastAll(new Ray(mPresPos,(transform.position - mPresPos).normalized), (transform.position - mPresPos).magnitude);
        
        if (bulletSpeed != 0)
        {
            transform.position += transform.forward * (bulletSpeed * Time.deltaTime);
        }
        for (int i = 0; i <hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
            
            
        }
        
    }

     void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
