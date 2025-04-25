using UnityEngine;

[RequireComponent(typeof(GroundCheck), typeof(Stats))]

public class Jump : MonoBehaviour
{
    private Stats stats;
    private GroundCheck groundCheck;
    private Rigidbody2D rb;
    private float jumpPower;
    private int maxJumpNumber = 1, jumpNumber = 0;
    
    void Start()
    {
        stats = GetComponent<Stats>();
        groundCheck = GetComponent<GroundCheck>();
        jumpPower = stats.GetJumpPower();
    }

    public void Jumping()
    {
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
