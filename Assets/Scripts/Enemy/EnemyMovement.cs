using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Enemycontroller enemycontroller;
    private Animator animator;
    private NavMeshAgent nav;
    private void Awake() 
    {
        nav = GetComponent<NavMeshAgent>();
        enemycontroller = GetComponent<Enemycontroller>();
        enemycontroller.OnAttack += Enemycontroller_OnAttack;
        animator.GetComponentInChildren<Animator>();
    }

    private void Update() {
        var x = nav.velocity.x;
        var y = nav.velocity.y;
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY",y);
    }

    private void Enemycontroller_OnAttack(Transform target)
    {
        nav.SetDestination(target.transform.position);
    }
}
