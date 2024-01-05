using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : JHCharacterController
{
    public Vector2 moveInput { get; private set; }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnFire(InputValue value)
    {
        IsFiring = value.isPressed;
    }

    public void OnJump(InputValue value)
    {
        IsJumping = value.isPressed;
        IsGround = value.isPressed; // test
    }

    public void OnDown(InputValue value)
    {
        IsDown = value.isPressed;
        CallDownEvent();
    }
}
