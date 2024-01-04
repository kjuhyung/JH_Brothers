using System;
using UnityEngine;

public class JHCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnFireEvent;
    public event Action OnJumpEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsFire { get; set; }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if(_timeSinceLastAttack <= 0.2f) // TODO - ��ź �ϳ��� ��ȯ �����ϰ� �����ؾ���
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if(IsFire && _timeSinceLastAttack > 0.2f)
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
