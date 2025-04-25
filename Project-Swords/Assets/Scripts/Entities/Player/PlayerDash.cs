using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private GroundCheck groundCheck;
    
    private Rigidbody2D rb;

   private float dashSpeed = 15f;
   private float dashDuration = 0.8f;
   private float dashTimer = 0f;
   private float dashCd = 3f;
   private float cdTimer = 0f;
   
   private Vector2 direction;

   private bool canDash = true;
   private bool isDashing = false;
   private bool isGrounded;


//

    private void Start()
    {
        PlayerBasicMovements.onSetCanMove?.Invoke(true);
        PlayerJump.onSetCanJump?.Invoke(true);
    }



     public void DashDirection(Vector2 input)
    {
        if (input != Vector2.zero)
        {
            direction = input;
        }
    }

}
