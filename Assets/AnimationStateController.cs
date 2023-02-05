using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Decides which buttons are actively pressed
        bool jumpButtonPressed = Input.GetButtonDown("Jump") ;
        bool walkButtonPressed = Input.GetAxis("Horizontal") != 0;
        bool attackButtonPressed = Input.GetButtonDown("Attack");
        
        //Checks if we already in any giving state
        bool isJumping = animator.GetBool("isJumping");
        bool isMoving = animator.GetBool("isMoving");
        bool isDashing = animator.GetBool("isDashing");
        bool isFalling = animator.GetBool("isFalling");
        bool isGrounded = animator.GetBool("isGrounded");
        bool isIdle = animator.GetBool("isIdle");
        
        
        
        // makes walk animation play
        if (isGrounded && walkButtonPressed)
        {
            animator.SetBool("isMoving", true);
            
            
        }
        else
        {
            animator.SetBool("isMoving", false);
        }



    }

   
}
