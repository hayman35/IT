using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private CharacterController character;
    Animator animator;

    [SerializeField]
    private float moveSpeed = 100;

    [SerializeField]
    private float turnSpeed = 5;

    private void Awake() {
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        character.SimpleMove(movement * Time.deltaTime * moveSpeed);

        animator.SetFloat("Speed", movement.magnitude);

        if(movement.magnitude > 0)
        {
        Quaternion newDirection = Quaternion.LookRotation(movement * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }
    }

}
