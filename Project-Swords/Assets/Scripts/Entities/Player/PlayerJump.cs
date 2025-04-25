using System;
using UnityEngine;

public class PlayerJump : Jump
{
    public static Action<bool> onSetCanJump{ get; set; }
    private void OnEnable()
    {
        onSetCanJump += SetCanJump;
    }

    private void OnDisable()
    {
        onSetCanJump -= SetCanJump;
    }

    private void SetCanJump(bool value)
    {
        canJump = value;
    }

}
