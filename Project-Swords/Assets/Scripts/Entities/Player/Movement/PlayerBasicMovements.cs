using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerBasicMovements : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private float speed = 0f;
    private Vector2 direction;
    private bool canMove = true, isMoving = false, isDashing = false;
    [SerializeField] private float acceleration = 1f, deceleration = 1f;

    public static Action<Vector2> onMove { get; set; }
    public static Action<bool> onSetCanMove { get; set; }
    public static Action onSetToMaxSpeed { get; set; }

    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerDash.onSetIsDashing += SetIsDashing;
        onSetCanMove += SetCanMove;
        onMove += Move;
        onSetToMaxSpeed += SetToMaxSpeed;
    }

    private void OnDisable()
    {
        PlayerDash.onSetIsDashing -= SetIsDashing;
        onSetCanMove -= SetCanMove;
        onMove -= Move;
        onSetToMaxSpeed -= SetToMaxSpeed;
    }
    private void SetIsDashing(bool value)
    {
        isDashing = value;
    }

    private void SetCanMove(bool value)
    {
        canMove = value;
    }

#region "Commentaire"
    // Update is called once per frame

    //if can move
    //Get input
    //then 
    //accelerate until max speed if we move and if speed isn't already at max speed
    //or decelerate until 0

    /*void Update()
    {
        if (!canMove) return;

        if(direction.x != 0 && speed < maxSpeed)
        {
            speed += acceleration;
        }
        if(direction.x == 0 && speed > 0)
        {
            speed -= deceleration;
        }

        rb.linearVelocityX = direction.x * speed; 
    }*/
#endregion
    void Update()
    {
        if (!canMove) return;
        if (isDashing) return;

        if (isMoving)
        {
            speed = Mathf.Lerp(speed, player.speed, acceleration * Time.deltaTime);
        }
        else if (speed > 0.2f)
        {
            speed = Mathf.Lerp(speed, 0, deceleration * Time.deltaTime);
        }
        else
        {
            SetSpeedToZero();
        }

        rb.linearVelocityX = direction.x * speed;
    }

    private void SetToMaxSpeed()        //use at the end of the dash
    {                                   //ork type code
        speed = player.speed;
    }

    private void SetSpeedToZero()
    {
        speed = 0f;
    }

    public void Move(Vector2 input)
    {
        if (input.x != 0)
        {
            direction = input;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
