using System;
using UnityEngine;

public class PlayerJump : Jump
{
    public static Action<bool> onSetCanJump { get; set; }
    public static Action onJump { get; set; }

    private void OnEnable()
    {
        onSetCanJump += SetCanJump;
        onJump += Jumping;
    }

    private void OnDisable()
    {
        onSetCanJump -= SetCanJump;
        onJump -= Jumping;
    }

    private void SetCanJump(bool value)
    {
        canJump = value;
    }

}
