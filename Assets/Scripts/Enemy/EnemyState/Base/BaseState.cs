using UnityEngine;

public abstract class BaseState : MonoBehaviour, IState
{
    protected EnemyController enemyController;
    protected EnemyStateMachine enemyStateMachine;

    protected bool Active = false;

    public void Init(EnemyController _enemyController, EnemyStateMachine _enemyStateMachine)
    {
        enemyController = _enemyController;
        enemyStateMachine = _enemyStateMachine;
    }

    public abstract void Enter();

    public abstract void Exit();
}
