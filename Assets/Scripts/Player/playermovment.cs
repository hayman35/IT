using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private CharacterController character;
    Animator animator;

    
    public float moveSpeed = 100;
    public float mouseSensitivity = 100.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    public float minX = -60f;
    public float maxX = 60f;
    public float jumpHeight = 8.0F;
    private Vector3 movement;
    Vector3 velocity;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public float gravity = -9.81f;
    public LayerMask groundMask;
    bool isGrounded;
    
 

    
    private void Start() {
        Vector3 rot = transform.localRotation.eulerAngles;
         rotY = rot.y;
         rotX = rot.x;
         Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake() {
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update() {
           
        
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var jump = Input.GetKeyDown(KeyCode.Space);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask); // creating a sphere is check if the player is grounded 

        /*
        Mouse Movement 
        */
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX,minX,maxX);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        /*
        Mouse Movement 
        */
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        movement = transform.right * horizontal + transform.forward *vertical;

        character.Move(movement * moveSpeed * Time.deltaTime);

        if (jump && isGrounded)
        {   
            animator.SetTrigger("jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity *Time.deltaTime;

        character.Move(velocity * Time.deltaTime);
        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY",vertical);
    }
}
