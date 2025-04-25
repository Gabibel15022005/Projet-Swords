using UnityEngine;

[RequireComponent(typeof(GroundCheck), typeof(Stats))]

public class Jump : MonoBehaviour
{
    protected Stats stats;
    protected GroundCheck groundCheck;
    protected Rigidbody2D rb;
    protected float jumpPower;
    protected int maxJumpNumber = 1, jumpNumber = 0;
    protected bool canJump = true;
    
    void Start()
    {
        stats = GetComponent<Stats>();
        groundCheck = GetComponent<GroundCheck>();
        rb = GetComponent<Rigidbody2D>();
        jumpPower = stats.GetJumpPower();
    }

    public void Jumping()
    {
        if (!canJump) return; 

        if(groundCheck.isGrounded)
        {
            jumpNumber = maxJumpNumber;
        }

        if(jumpNumber > 0)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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
