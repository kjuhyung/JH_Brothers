using System;
using UnityEngine;

public class JHCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnFireEvent;
    public event Action OnJumpEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsFiring { get; set; }
    protected bool IsJumping { get; set; }
    protected bool IsGround { get; set; }

    protected virtual void Update()
    {
        HandleAttack();
        HandleJump();
    }

    private void HandleJump()
    {
        if (IsJumping && IsGround)
        {
            CallJumpEvent();
        }
    }

    private void HandleAttack()
    {
        if(_timeSinceLastAttack <= 0.2f) // TODO - 폭탄 하나만 소환 가능하게 수정해야함
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if(IsFiring && _timeSinceLastAttack > 0.2f)
        {
            _timeSinceLastAttack = 0f;
            CallFireEvent();
        }
    }

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
