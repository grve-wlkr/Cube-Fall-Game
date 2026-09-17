using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Details")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check Details")]
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D myBody;
    private float horizontalInput;
    private float platformVelocityX;
    private bool isGrounded;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move the player based on horizontal input + moving platform push
        myBody.velocity = new Vector2((horizontalInput * moveSpeed) + platformVelocityX, myBody.velocity.y);
        platformVelocityX = 0f; // Reset platform push frame-by-frame
    }

    // Update horizontal input based on player input
    public void OnMove(InputValue value) => horizontalInput = value.Get<float>();

    public void OnJump(InputValue value)
    {
        if (!value.isPressed) return; // Only jump when the button is pressed, not released

        if (IsPointerOverUI()) return; // Prevent jumping if the pointer is over a UI element

        if (isGrounded) // Check if the player is grounded before allowing a jump
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            isGrounded = false; // Set grounded status to false after jumping
        }
    }

    public void PlatformMove(float x) => platformVelocityX = x;

    private bool IsPointerOverUI() // Check if the pointer is over a UI element
    {
        if (EventSystem.current == null) return false;

        // Check for mouse input on PC
        if (EventSystem.current.IsPointerOverGameObject()) return true;
        
        return Touchscreen.current != null && Touchscreen.current.touches.Count > 0 
        && EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].
        touchId.ReadValue()); // Check for touch input on mobile devices
    }

    private void OnCollisionStay2D(Collision2D collisionTarget)
    {
        // Check if the collided object is in the ground layer
        if (((1 << collisionTarget.gameObject.layer) & groundLayer) == 0) return;

        for (int i = 0; i < collisionTarget.contactCount; i++)
        {
            // Get the contact point of the collision
            ContactPoint2D contact = collisionTarget.GetContact(i);
            if (contact.normal.y > 0.65f) // Check if the contact normal indicates a ground surface
            {
                isGrounded = true; // Player is grounded
                return;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collisionTarget)
    {
        // Reset ground status when the player exits collision with the ground
        if (((1 << collisionTarget.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false; // Player is no longer grounded when exiting collision with ground
        }
    }

    



} // class
