using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private int damage = 1;
    public AudioSource gunfireSource;

    public GameObject firePoint;
    public GameObject muzzleFlash;
    public float attackefreshRate = 1.5f;
    public GameObject bulletFX;
    public float bulletSpeed = 10f;
    public GameObject flare;

    private Enemycontroller enemycontroller;
    private Transform target;
    private float attackTimer;



    private void Awake() 
    {
        enemycontroller = GetComponent<Enemycontroller>();
        enemycontroller.OnAttack += Enemycontroller_OnAttack;

    }

    private void Enemycontroller_OnAttack(Transform target)
    {
        this.target = target;
        
    }

    private void Update() 
    {
        if (target != null)
        {
            attackTimer += Time.deltaTime;

            if(CanAttack())
            {
                Attack();
            }
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= attackefreshRate;

    }

    private void Attack()
    {
        attackTimer = 0;
        // gunfireSource.Play();
        // GameObject muzzleFlashGO = Instantiate(muzzleFlash, flare.transform.position, flare.transform.rotation);
        // Destroy(muzzleFlashGO, 2f);
        // GameObject bulletGO = Instantiate(bulletFX, firePoint.transform.position, firePoint.transform.rotation);
        // bulletGO.GetComponent<Rigidbody>().AddForce(Vector3.forward * -bulletSpeed, ForceMode.VelocityChange);
        // Destroy(bulletGO,4f);

    }
}
