using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isRunning", true);
          
        } else if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isRunning", false);
            
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            Debug.Log("Jumping");
            animator.SetBool("isJumping", true);
            
        }
        else
        {
            animator.SetBool("isJumping", false);

        }

        animator.SetBool("isGrounded", controller.isGrounded);
        
    }

    private void StopIdle()
    {
        animator.SetBool("isIdle", false);
    }
}
