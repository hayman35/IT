using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemycontroller : MonoBehaviour
{
    private Animator animator;
    public event Action<Transform> OnAttack = delegate {};
    private void OnTriggerEnter(Collider other) {
        var player = other.GetComponent<PlayerMovment>();
        
        if (player != null)
        {
            OnAttack(player.transform);
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            
        }
    }
}
