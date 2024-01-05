using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private IdleState idleState;
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private AttackState attackState;
    [SerializeField] private FleeingState fleeingState;
    [SerializeField] private DeadState deadState;
 
    public IState CurrentState { get; protected set; }

    public Rigidbody2D body;

    public EnemyStateMachine(IdleState _idleState, PatrolState _patrolState, AttackState _attackState, FleeingState _fleeingState, DeadState _deadState)
    {
        this.idleState = _idleState;
        this.patrolState = _patrolState;
        this.attackState = _attackState;
        this.fleeingState = _fleeingState;
        this.deadState = _deadState;
        idleState.Init(this);
        patrolState.Init(this);
        attackState.Init(this);
        fleeingState.Init(this);
        deadState.Init(this);
        body = GetComponent<Rigidbody2D>();
    }

    public void ChangeState(IState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }

    public void Move()
    {
        
    }
}
