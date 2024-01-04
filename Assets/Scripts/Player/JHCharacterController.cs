using System;
using UnityEngine;

public class JHCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnFireEvent;
    public event Action OnJumpEvent;

    protected void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    protected void CallFireEvent()
    {
        OnFireEvent?.Invoke();
    }

    protected void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }

}
