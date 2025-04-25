using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private GroundCheck groundCheck;
    private Rigidbody2D rb;

    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.8f;
    private float dashTimer = 0f;
    [SerializeField] private float dashCd = 3f;
    private float cdTimer = 0f;
    
    private Vector2 direction = new Vector2(1,0);
    private float gravityBeforeDash = 1;

    private bool canDash = true;
    private bool isDashing = false; // pour savoir combien de temp faire le dash

    public static Action onDash { get; set; }  // ajouter la fonction dans PlayerInputManager et dans ce script
    public static Action<bool> onSetIsDashing { get; set;} // utiliser cette event dans les vérifs pour le mouvement et le jump

    private void Start()
    {
        groundCheck = GetComponent<GroundCheck>();
        rb = GetComponent<Rigidbody2D>();

        PlayerBasicMovements.onSetCanMove?.Invoke(true);
        PlayerJump.onSetCanJump?.Invoke(true);
    }

    private void OnEnable()
    {
        PlayerBasicMovements.onMove += DashDirection;
        onSetIsDashing += SetIsDashing;
        onDash += Dash;
    }

    private void OnDisable()
    {
        PlayerBasicMovements.onMove -= DashDirection;
        onSetIsDashing -= SetIsDashing;
        onDash -= Dash;
    }

    private void SetIsDashing(bool value)
    {
        isDashing = value;
    }

    private void Update()
    {
        if (isDashing) CheckDashDuration();  // pour faire durer le dash un certain temp

        if (!canDash) CheckCooldown(); // pour check si le joueur peut dash ou non

    }

    private void Dash()
    {
        if (!canDash) return;

        //Debug.Log("Dash");

        canDash = false;

        onSetIsDashing?.Invoke(true); // stop les autres mouvement du joueur

        
        gravityBeforeDash = rb.gravityScale;    // enregistre le gravity scale du joueur dans gravityBeforeDash
        rb.gravityScale = 0;                    // mettre la gravityScale a 0

        rb.linearVelocityY = 0;                 // mettre le linear velocity Y a 0
        rb.linearVelocityX = direction.x * dashSpeed;         // set la velocity X a dashSpeed

    }

    private void StopDash()
    {
        onSetIsDashing?.Invoke(false);          // remet les autres mouvement du joueur les autres mouvement du joueur
        dashTimer = 0f;
        
        rb.gravityScale = gravityBeforeDash;    // rb.gravityScale = gravityBeforeDash
    }

    private void ResetDash()
    {
        canDash = true;
        cdTimer = 0f;
    }

    public void DashDirection(Vector2 input)
    {
        if (input.x != 0)
        {
            direction = input;
        }
    }
    
    private void CheckDashDuration()
    {
        if (isDashing && dashDuration > dashTimer)
        {
            //Debug.Log("CheckDashDuration is checking");
            dashTimer += Time.deltaTime;
        }
        else
        {
            StopDash();
        }
    }

    private void CheckCooldown()
    {
        if (dashCd > cdTimer || !groundCheck.isGrounded)
        {
            //Debug.Log("CheckCooldown is checking");
            cdTimer += Time.deltaTime;
        }
        else
        {
            ResetDash();
        }
    }

}
