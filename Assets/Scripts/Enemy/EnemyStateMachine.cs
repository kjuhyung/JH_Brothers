using UnityEngine;

enum StateType
{
    Idle,
    Patrol,
    Attack,
    Fleeing,
    Dead,
}

public class EnemyStateMachine : MonoBehaviour
{
    public IState CurrentState { get; protected set; }

    private IdleState idleState;
    private PatrolState patrolState;
    private AttackState attackState;
    private FleeingState fleeingState;
    private DeadState deadState;

    public void ChangeState(IState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }
}
