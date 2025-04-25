using System;
using UnityEngine;

public class PlayerJump : Jump
{
    public static Action<bool> onSetCanJump { get; set; }
    public static Action onJump { get; set; }
    public static Action onReleaseJump { get; set; }

    private void OnEnable()
    {
        onSetCanJump += SetCanJump;
        onJump += Jumping;
        PlayerDash.onSetIsDashing += SetIsDashing;
        onReleaseJump += ReleaseJump;
    }

    private void OnDisable()
    {
        onSetCanJump -= SetCanJump;
        onJump -= Jumping;
        PlayerDash.onSetIsDashing -= SetIsDashing;
        onReleaseJump -= ReleaseJump;
    }

    private void ReleaseJump()
    {
        if (rb.linearVelocityY > 0) rb.linearVelocityY /= 2; // si tu relache le bouton de saut et que tu est en train de monter alors divise la monté
    }

    private void SetIsDashing(bool value)
    {
        isDashing = value;
    }

    private void SetCanJump(bool value)
    {
        canJump = value;
    }

}
