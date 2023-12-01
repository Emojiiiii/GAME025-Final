using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Reference to the Rigidbody2D component for the main character.
    Rigidbody2D MainCharacter;

    // Movement speed of the main character.
    public float move = 5;

    // Dash distance for the main character.
    public float dashAmount = 5;

    // Jump force applied to the main character.
    public float jumpForce = 5000f;

    // Layer mask for detecting the ground.
    public LayerMask groundLayer;

    // Transform representing the ground check position.
    public Transform groundCheck;

    // Boolean indicating whether the main character is grounded.
    private bool isGrounded;

    // Vector to store movement input.
    Vector2 movement;

    // Boolean indicating whether the dash button is pressed.
    private bool isDashButtonDown;

    // Vector to store the movement direction during dash.
    private Vector3 moveDir; 

    void Start()
    {
        // Get the Rigidbody2D component of the main character.
        MainCharacter = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal movement input.
        movement.x = Input.GetAxisRaw("Horizontal");

        // Check if the main character is grounded using a circle overlap check.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 10000f, groundLayer);
        //Debug.Log("Is Grounded: " + isGrounded);

        // Handle jumping if grounded and space key is pressed.
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check for Left Shift key press to trigger dash.
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            isDashButtonDown = true;
        }
    }

    void FixedUpdate()
    {
        // Normalize the movement vector.
        movement.Normalize();

        // Handle movement or dash based on input.
        if (isDashButtonDown)
        {
            Dash();
            isDashButtonDown = false;
        }
        else
        {
            MainCharacter.velocity = movement * move;
        }
    }

    void Dash()
    {
        // Log dash and calculate dash position.
        Debug.Log("Dash!");
        Vector2 dashPosition = MainCharacter.position + movement * dashAmount;

        // Move the main character to the calculated dash position.
        MainCharacter.MovePosition(dashPosition);
    } 

    void Jump()
    {
        // Apply an upward force to simulate jumping.
        MainCharacter.AddForce(new Vector2(0f, jumpForce));
        Debug.Log("Jump!");
    }
}


