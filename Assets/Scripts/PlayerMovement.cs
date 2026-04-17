using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float playerSpeed = 2f; // player speed
    public float horizontalSpeed = 3f; // horizontal speed
    public float rightLimit = 5.5f; // these are the boundaries for my endless runner
    public float leftLimit = -5.5f;

    [Header("Jump Settings")]
    public float jumpForce = 10f;       // Vertical jump height
    public float gravity = 25f;         // Fall speed
    private bool isJumping = false;
    private float jumpVelocity = 0f;
    private float groundY;             // Starting Y position

    [Header("Dash Settings")] // this shows the distance of the dash
    public float dashForce = 10f;
    public float dashCooldown = 2f; // dash cool down
    private float lastDashTime = -10f; // tracks the last dash 
    public int maxDashes = 5; // the max dash is at 5 
    private int remainingDashes; // this holds the current remaining dashes 

    [Header("Particles")]
    [SerializeField] ParticleSystem dashDust;
    [SerializeField] ParticleSystem jumpDust; // optional jump particle

    void Start()
    {
        groundY = transform.position.y; // y position as ground level
        remainingDashes = maxDashes; 

        // Initialize dash UI
        DashInfo.remainingDashes = remainingDashes;
         // we store the starting y position as ground level
    }

    void Update()
    {
        // Forward automatic movement
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        // Horizontal movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftLimit) // prevents moving beyond the left bounary 
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightLimit) //prevents moving beyond right boundary 
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }

        // JUMP simulation (Spacebar) with slight forward boost
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jumpVelocity = jumpForce;
            isJumping = true;

            if (jumpDust != null)
                jumpDust.Play(); // optional particle when jumping
        }

        if (isJumping)
        {
            // Vertical + forward jump
            transform.Translate(new Vector3(0, jumpVelocity, playerSpeed * 0.3f) * Time.deltaTime);

            // Apply gravity
            jumpVelocity -= gravity * Time.deltaTime;

            // Check if player landed
            if (transform.position.y <= groundY)
            {
                transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
                isJumping = false;
            }
        }

        // DASH (Shift) with limit
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDashTime >= dashCooldown && remainingDashes > 0)
        {
            transform.Translate(Vector3.forward * dashForce, Space.World);
            lastDashTime = Time.time;

            if (dashDust != null)
                dashDust.Play();

            remainingDashes--; // this decreases the dashes 
            DashInfo.remainingDashes = remainingDashes; // cooldown finished and player has remaining dashes 
        }
    }
}