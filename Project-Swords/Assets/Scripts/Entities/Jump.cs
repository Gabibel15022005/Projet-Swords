using UnityEngine;

[RequireComponent(typeof(GroundCheck), typeof(Stats))]

public class Jump : MonoBehaviour
{
    protected Player player;
    protected GroundCheck groundCheck;
    protected Rigidbody2D rb;
    protected int maxJumpNumber = 1, jumpNumber = 0;
    protected bool canJump = true;
    protected bool isDashing = false;
    
    void Start()
    {
        player = GetComponent<Player>();
        groundCheck = GetComponent<GroundCheck>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jumping()
    {
        if (!canJump) return; 
        if (isDashing) return;

        if(groundCheck.isGrounded)
        {
            jumpNumber = maxJumpNumber;
        }

        if(jumpNumber > 0)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * player.jumpPower, ForceMode2D.Impulse);
            jumpNumber--;
        }
    }

    void Update()
    {
        if(!groundCheck.isGrounded && jumpNumber == maxJumpNumber)
        {
            jumpNumber--;
        }
    }
}
