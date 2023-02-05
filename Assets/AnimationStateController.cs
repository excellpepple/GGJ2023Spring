using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    public PlayerController controller;

    public Dash dasher;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Decides which buttons are actively pressed
        bool jumpButtonPressed = Input.GetAxis("Vertical") > 0;
        bool walkButtonPressed = Input.GetAxis("Horizontal") != 0;
        bool attackButtonPressed = Input.GetButtonDown("Attack");
        
        //Checks if we already in any giving state
        bool isJumping = animator.GetBool("isJumping");
        bool isMoving = animator.GetBool("isMoving");
        bool isDashing = dasher.isDashing;
        bool isFalling = animator.GetBool("isFalling");
        bool isGrounded = controller.groundedPlayer;
        bool isIdle = animator.GetBool("isIdle");
        animator.SetBool("isGrounded", isGrounded);
        
        
        // makes walk animation play
        if (isGrounded && walkButtonPressed)
        {
            animator.SetBool("isMoving", true);
            
            
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        
        // makes player Idol
        if (isGrounded)
        {
            animator.SetBool("isIdle", true);
        }
        else
        {
            animator.SetBool("isIdle", false);
        }
        
        // make player Jump
        if (isGrounded && jumpButtonPressed)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (isDashing)
        {
            animator.SetBool("isDashing", true);

        }
        else
        {
            animator.SetBool("isDashing", false);
        }


    }

   
}
