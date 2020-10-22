using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Enemycontroller enemycontroller;
    Animator animator;
    private NavMeshAgent nav;
    private Transform target;
    private void Awake() 
    {
        nav = GetComponent<NavMeshAgent>();
        enemycontroller = GetComponent<Enemycontroller>();
        enemycontroller.OnAttack += Enemycontroller_OnAttack;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (target != null)
        {
            nav.SetDestination(target.position);
            
            float speed = nav.velocity.magnitude;
            animator.SetFloat("Speed", speed);
        }
        
        
    }

    private void Enemycontroller_OnAttack(Transform target)
    {
        this.target = target;
        
    }
}
