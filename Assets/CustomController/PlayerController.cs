using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private bool isGrounded = false;
    private bool jumpButtonPressed = false;
    private int jumpsMade = 0;
    public int maxJumps = 2;
    public Animator animator;
    private float VerticalVelocity;

    internal void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Setting the z-axis of the player to 0. */
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);

        /* This is checking if the player is on the ground and if the player is on the ground, the player's velocity is set
        to 0. */
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            // Press the character down to the floor to avoid jitter "true-false"
            // of the isGrounded property.
            // To do it, add some small gravity (or velocity in your terms).
            VerticalVelocity = gravityValue * 0.1f;
            controller.Move(new Vector3(0, VerticalVelocity * Time.deltaTime, 0));
        }
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            
        }

        /* This is checking if the player is pressing the right or left arrow keys and if they are, the player will move in
        that direction. */
        float horizontal = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }

        /* This is moving the player in the direction of the arrow keys. */
        Vector3 move = new Vector3(horizontal, 0, 0);
        controller.Move(move * (Time.deltaTime * playerSpeed));

        /* This is making the player face the direction that they are moving in. */
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        /* This is making the player jump. */
        // Changes the height position of the player..
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        // Limit the maximum jump height
        if (playerVelocity.y < -Mathf.Sqrt(jumpHeight * 3.0f * gravityValue))
        {
            playerVelocity.y = -Mathf.Sqrt(jumpHeight * 3.0f * gravityValue);
        }

        // Increase the magnitude of gravityValue to make the player fall faster
        /* This is making the player fall faster. */
        float fallMultiplier = 2.0f;
        playerVelocity.y += gravityValue * fallMultiplier * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.DownArrow)) || Input.GetKey(KeyCode.S))
        {
            Debug.Log("Going down");
        }



    }
    /*public void DecreaseHitPoints()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            // Trigger death or game over event
        }*/



    /*public override void TakeDamage(float damage)
    {
        hitPoints -= (int) damage;
    }*/

}