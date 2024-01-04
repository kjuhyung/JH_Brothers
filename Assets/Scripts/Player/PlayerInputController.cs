using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : JHCharacterController
{
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnFire()
    {
        CallFireEvent();
    }

    public void OnJump()
    {
        CallJumpEvent();
    }
}
