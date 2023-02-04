using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private bool isGrounded = false;
    private bool jumpButtonPressed = false;
    private int jumpsMade = 0;
    private int maxJumps = 2;
    internal void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontal = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }

        Vector3 move = new Vector3(horizontal, 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && groundedPlayer && jumpsMade < maxJumps))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jumpsMade++;
        }
        if (controller.isGrounded)
        {
            jumpsMade = 0;
        }
        // Limit the maximum jump height
        if (playerVelocity.y < -Mathf.Sqrt(jumpHeight * 3.0f * gravityValue))
        {
            playerVelocity.y = -Mathf.Sqrt(jumpHeight * 3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.DownArrow)) || Input.GetKey(KeyCode.S))
        {
            Debug.Log("Going down");
        }


    }
}
