using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : JHCharacterController
{
    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove");
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire");
        IsFire = value.isPressed;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("OnJump");
            CallJumpEvent();
        }
    }
}
