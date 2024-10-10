using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float rotationSpeed = 100f;  // Speed of rotation

    private CharacterController controller;  // Character controller component
    private Vector3 moveDirection;  // Movement direction

    public PlayerDMG playerDMGScript;

    void Start()
    {
        // Get the CharacterController attached to the player
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Call the movement method
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");  // W/S or Up/Down arrows

        // Move in the direction relative to the player's current forward
        moveDirection = transform.forward * moveZ + transform.right * moveX;

        // Move the player using CharacterController
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Handle rotation using the mouse
        float mouseX = Input.GetAxis("Mouse X");  // Mouse horizontal movement

        // Rotate the player around the Y-axis (turning left and right)
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerDMGScript.HealDamage(20,collision);
        Debug.Log("Collided with: " + collision.gameObject.name);
           
    }
}
