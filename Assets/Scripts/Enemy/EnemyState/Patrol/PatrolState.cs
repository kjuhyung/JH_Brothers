using UnityEngine;

public class PatrolState : BaseState
{
    public float moveSpeed;
    public float moveTime = 1;
    public int nextMove = 0;

    private float curTime = 0;
    private Vector2 _velocity;

    private void Start()
    {
        moveSpeed = enemyController.enemyData.Speed;
    }

    private void Update()
    {
        if (Active)
        {
            curTime += Time.deltaTime;

            if (nextMove == 0 || curTime > moveTime)
            {
                Exit();
            }
            else
            {
                enemyController.body.velocity = new Vector2(nextMove, enemyController.body.velocity.y);
            }
        }
    }

    public override void Enter()
    {
        Think();
        curTime = 0;
        Active = true;
    }

    public override void Exit()
    {
        if (Active)
        {
            Active = false;
            enemyStateMachine.ChangeState(StateType.Idle);
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2); 
    }
}
