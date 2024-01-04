using UnityEngine;

public abstract class BaseState : MonoBehaviour, IState
{
    protected EnemyStateMachine enemyStateMachine;

    public void Init(EnemyStateMachine _enemyStateMachine)
    {
        enemyStateMachine = _enemyStateMachine;
    }

    public abstract void Enter();

    public abstract void Exit();
}
