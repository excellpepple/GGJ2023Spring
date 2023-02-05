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
        animator.SetBool("isGrounded", controller.groundedPlayer);
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isRunning", true);
          
        } else if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isRunning", false);
            
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
           
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", true);
            animator.SetBool("isGrounded", false);
            
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        
        
    }

    private void StopIdle()
    {
        animator.SetBool("isIdle", false);
    }
}
