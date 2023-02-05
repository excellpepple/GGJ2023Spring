using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedControls : MonoBehaviour
{
    private CharacterController characterController;
    private float jumpForce = 10f;
    private int jumpCount = 0;
    public float dashSpeed = 10.0f;
    public float dashDuration = 0.5f;
    private float dashTimeLeft;
    private bool isDashing;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpCount++;
        }

        if (jumpCount == 2 && !characterController.isGrounded)
        {
            Vector3 force = new Vector3(0, jumpForce, 0);
            characterController.Move(force * Time.deltaTime);
            jumpCount = 0;

            if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
            {
                StartCoroutine(DashCoroutine());
            }
        }
    }

    private IEnumerator DashCoroutine()
    {
        isDashing = true;
        dashTimeLeft = dashDuration;

        while (dashTimeLeft > 0)
        {
            Vector3 dashDirection = transform.forward;
            transform.position = transform.position + dashDirection * dashSpeed * Time.deltaTime;
            dashTimeLeft -= Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }

}

