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
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
 
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
 
        rotX = Mathf.Clamp(rotX,minX,maxX);
 
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        
        Move(horizontal,vertical);
    }

    private void Move(float x, float y)
    { 

        var movement = new Vector3(x, 0f, y).normalized;

        // Setting the camera direction so that movement happens both ways 
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;

        if (movement.magnitude >= 0.1f)
        {
            character.Move(movement * moveSpeed * Time.deltaTime);
        }
        

        character.SimpleMove(transform.forward * moveSpeed * y);
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY",y);

        
    }

}
