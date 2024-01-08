using UnityEngine;

public class AttackState : BaseState
{
    public override void Enter()
    {
        enemyController.body.velocity = Vector2.zero;
        curTime = 0.0f;
        Active = true;
    }

    public override void Exit()
    {
        Active = false;
    }
}
