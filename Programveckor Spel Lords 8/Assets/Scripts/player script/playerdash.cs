using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash2D : MonoBehaviour
{
    public float dashSpeed = 20f;         // Speed of the dash
    public float dashDuration = 0.2f;     // Duration of the dash
    public float dashCooldown = 1f;       // Time before you can dash again
    private float dashCooldownTimer = 3f; // Timer to track cooldown

    private bool isDashing = false;       // Whether the player is currently dashing
    private float dashTime = 0f;          // Timer to track dash duration

    private Vector2 dashDirection;        // Direction of the dash
    private Rigidbody2D rb;               // Rigidbody2D reference

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Handle cooldown timer
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        // When Q is pressed and cooldown has elapsed, dash in the player's current movement direction
        if (Input.GetKeyDown(KeyCode.Q) && dashCooldownTimer <= 0f && !isDashing)
        {
            Dash();  // Initiate the dash
        }

        // If the dash is in progress, update the dash timer
        if (isDashing)
        {
            dashTime += Time.deltaTime;

            // Stop dashing when the dash duration is over
            if (dashTime >= dashDuration)
            {
                isDashing = false;
                dashCooldownTimer = dashCooldown; // Start cooldown after dash
                dashTime = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        // While dashing, apply movement in the dash direction
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
        }
    }

    // Initiate the dash
    void Dash()
    {
        isDashing = true;

        // Dash in the direction the player is currently moving
        dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // If no input is given (player is not pressing any direction keys), dash forward
        if (dashDirection.magnitude == 0)
        {
            dashDirection = transform.right;  // Default to the direction the player is facing (right)
        }
    }
}
