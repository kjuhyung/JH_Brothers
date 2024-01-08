using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public enum StateType
{
    Idle,
    Patrol,
    Attack,
    Fleeing,
    Dead,
}

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private IdleState idleState;
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private AttackState attackState;
    [SerializeField] private FleeingState fleeingState;
    [SerializeField] private DeadState deadState;
 
    public IState CurrentState { get; protected set; }

    public EnemyStateMachine(EnemyController enemyController, IdleState _idleState, PatrolState _patrolState, AttackState _attackState, FleeingState _fleeingState, DeadState _deadState)
    {
        idleState = _idleState;
        patrolState = _patrolState;
        attackState = _attackState;
        fleeingState = _fleeingState;
        deadState = _deadState;
        idleState.Init(enemyController, this);
        patrolState.Init(enemyController, this);
        attackState.Init(enemyController, this);
        fleeingState.Init(enemyController, this);
        deadState.Init(enemyController, this);

        ChangeState(StateType.Idle);
    }

    public void ChangeState(StateType newState)
    {
        CurrentState?.Exit();
        switch(newState)
        {
            case StateType.Idle:
                CurrentState = idleState;
                break;
            case StateType.Patrol:
                CurrentState = patrolState;
                break;
            case StateType.Attack:
                CurrentState = attackState;
                break;
            case StateType.Fleeing:
                CurrentState = fleeingState;
                break;
            case StateType.Dead:
                CurrentState = deadState;
                break;
            default:
                CurrentState = idleState;
                break;
        }
        CurrentState?.Enter();
    }
}
