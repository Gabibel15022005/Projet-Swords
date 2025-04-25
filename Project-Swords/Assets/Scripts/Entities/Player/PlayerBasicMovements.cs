using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerBasicMovements : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private float maxSpeed;
    private float speed = 0f;
    private Vector2 direction;
    private bool canMove = true, isMoving = false;
    [SerializeField]private float acceleration = 1f, deceleration = 1f;


    public static Action<bool> onSetCanMove{ get; set; }
    private void OnEnable()
    {
        onSetCanMove += SetCanMove;
    }

    private void OnDisable()
    {
        onSetCanMove -= SetCanMove;
    }

    private void SetCanMove(bool value)
    {
        canMove = value;
    }

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = player.GetSpeed();
    }

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

    void Update()
    {
        if (!canMove) return;

        if (isMoving)
        {
            speed = Mathf.Lerp(speed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (speed > 0.2f)
        {
            speed = Mathf.Lerp(speed, 0, deceleration * Time.deltaTime);
        }
        else
        {
            setSpeedToZero();
        }

        rb.linearVelocityX = direction.x * speed;
    }

    private void setToMaxSpeed()        //use at the end of the dash
    {                                   //ork type code
        speed = maxSpeed;
    }

    private void setSpeedToZero()
    {
        speed = 0f;
    }

    public void Move(Vector2 input)
    {
        if (input != Vector2.zero)
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
