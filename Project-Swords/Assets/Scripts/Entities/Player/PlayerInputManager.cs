using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(
    typeof(Player), 
    typeof(PlayerJump), 
    typeof(PlayerBasicMovements)
)]

public class PlayerInputManager : MonoBehaviour
{
    private bool hasAllScripts = false;
    private bool isMoving = false;
    [SerializeField] private float inputOffSet = 0.3f;
    private Vector2 oldInput = Vector2.zero;

    private void Start()
    {
        hasAllScripts = true;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!hasAllScripts) return;

        Vector2 input = ApplyOffSet(context.ReadValue<Vector2>());

        if (isMoving)
        {
            PlayerBasicMovements.onMove?.Invoke(input);
        }
        else
        {
            PlayerBasicMovements.onMove?.Invoke(Vector2.zero);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!hasAllScripts) return;

        if (context.started)
        {
            PlayerJump.onJump?.Invoke();
        }
        else if (context.canceled)
        {
            PlayerJump.onReleaseJump?.Invoke();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!hasAllScripts) return;

        if (context.started)
        {
            PlayerDash.onDash?.Invoke();
        }
    }

    private Vector2 ApplyOffSet(Vector2 input)
    {
        //Debug.Log($"context : {input}");

        input = input.normalized;

        //Debug.Log($"context.normalized : {input}");

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

        if (input != Vector2.zero) isMoving = true;
        else isMoving = false;
        
        //Debug.Log($"input : {input}");

        return input;
    }

}
