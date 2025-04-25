using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(
    typeof(Player), 
    typeof(PlayerJump), 
    typeof(PlayerBasicMovements)
)]

public class PlayerInputManager : MonoBehaviour
{
    private PlayerBasicMovements playerMove;
    private PlayerJump playerJump;
    private bool hasAllScripts = false;
    private float inputOffSet = 0.3f;

    private void Start()
    {
        if (TryGetComponent(out PlayerBasicMovements moveScript)) playerMove = moveScript;
        if (TryGetComponent(out PlayerJump jumpScript)) playerJump = jumpScript;

        hasAllScripts = true;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!hasAllScripts) return;

        Vector2 input = context.ReadValue<Vector2>();

        input = ApplyOffSet(input);

        if (context.started)
        {
            playerMove.Move(input);
        }
        else if (context.canceled)
        {
            playerMove.Move(Vector2.zero);
        }
    }

     public void OnJump(InputAction.CallbackContext context)
    {
        if (!hasAllScripts) return;

        if (context.started)
        {
            playerJump.Jumping();
        }
    }


    private Vector2 ApplyOffSet(Vector2 input)
    {
        if(input.x < inputOffSet && input.x > -inputOffSet)
        {
            input.x = 0;
        }
        else if (input.x > inputOffSet)
        {
            input.x = 1;
        }
        else if (input.x < -inputOffSet)
        {
            input.x = -1;
        }

        if(input.y < inputOffSet && input.y > -inputOffSet)
        {
            input.y = 0;
        }
        else if (input.y > inputOffSet)
        {
            input.y = 1;
        }
        else if (input.y < -inputOffSet)
        {
            input.y = -1;
        }
        
        //Debug.Log($"input : {input}");

        return input;
    }

}
