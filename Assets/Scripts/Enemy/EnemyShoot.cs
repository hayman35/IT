using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private int damage = 1;
    public AudioSource gunfireSource;

    public Transform firePoint;
    public float attackefreshRate = 1.5f;
    public GameObject rocket;
    public float rocketSpeed = 10f;
    public AudioSource rocketSound;

    private Enemycontroller enemycontroller;
    private Transform target;
    private float attackTimer;



    private void Awake() 
    {
        enemycontroller = GetComponent<Enemycontroller>();
        // enemycontroller.OnAttack += Enemycontroller_OnAttack;

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

    public void Attack()
    {
        attackTimer = 0;
        rocketSound.Play();
        GameObject rocketGo = Instantiate(rocket,firePoint.position,firePoint.rotation);
        rocketGo.GetComponent<Rigidbody>().AddForce(firePoint.forward * rocketSpeed,ForceMode.Impulse);
        Destroy(rocketGo,2f);
      

    }
}
