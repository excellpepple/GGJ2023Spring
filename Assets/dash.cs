using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    private float dashTime;
    private Vector2 dashDirection;
    private bool isDashing = false;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if Shift key is pressed and a direction key (left arrow or right arrow) is also pressed
        if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            // Set the dash direction based on the direction key pressed
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dashDirection = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                dashDirection = Vector2.right;
            }

            // Set the dash time and activate the dash
            dashTime = dashDuration;
            isDashing = true;
        }

        // If the character is currently dashing
        if (isDashing)
        {
            // Decrement the dash time
            dashTime -= Time.deltaTime;

            // Move the character in the dash direction
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime);

            // If the dash time has expired, stop the dash
            if (dashTime <= 0)
            {
                isDashing = false;
            }
        }
    }
}