using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private IdleState idleState;
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private AttackState attackState;
    [SerializeField] private FleeingState fleeingState;
    [SerializeField] private DeadState deadState;

    private EnemyStateMachine fsm;
    public Rigidbody2D body;
    public EnemySO enemyData;
    public bool direction = true;

    private int maxHealth;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        fsm = new EnemyStateMachine(this, idleState, patrolState, attackState, fleeingState, deadState);
        maxHealth = enemyData.MaxHealth;
    }

    private void Update()
    {
        Debug.Log(body.velocity);
        if ((body.velocity.x > 0.01f && !direction) || (body.velocity.x < -0.01f && direction))
        {
            gameObject.transform.localScale = direction ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            direction = !direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            fsm.ChangeState(StateType.Attack);
        }
        else if(collision.TryGetComponent<PlayerBomb>(out PlayerBomb PlayerBomb))
        {
            fsm.ChangeState(StateType.Fleeing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            fsm.ChangeState(StateType.Idle);
        }
    }

    
}
