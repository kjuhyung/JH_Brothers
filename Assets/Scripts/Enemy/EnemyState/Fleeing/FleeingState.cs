using UnityEngine;

public class FleeingState : BaseState
{
    private bool direction;
    private float speed;

    private void Start()
    {
        speed = enemyController.enemyData.Speed * 0.5f;
    }

    public override void Enter()
    {
        Debug.Log("Enter : Fleeing");
        direction = enemyController.direction;
        curTime = 0.0f;
        Active = true;
    }

    private void Update()
    {
        if(Active)
        {
            curTime += Time.deltaTime;
            enemyController.body.velocity = new Vector2(direction ? (speed * -1) : speed, enemyController.body.velocity.y);
            if (curTime > 2.0f)
            {
                enemyStateMachine.ChangeState(StateType.Idle);
            }
        }
    }


    public override void Exit()
    {
        Debug.Log("Exit : Fleeing");
        Active = false;
    }
}
