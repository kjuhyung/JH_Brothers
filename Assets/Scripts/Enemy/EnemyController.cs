using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private IdleState idleState;
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private AttackState attackState;
    [SerializeField] private FleeingState fleeingState;
    [SerializeField] private DeadState deadState;

    private EnemyStateMachine fsm;

    private void Awake()
    {
        fsm = new EnemyStateMachine(idleState, patrolState, attackState, fleeingState, deadState);
    }

}
