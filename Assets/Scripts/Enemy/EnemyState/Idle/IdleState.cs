using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        Debug.Log("Enter : Idle");
        enemyController.body.velocity = Vector2.zero;
        curTime = 0.0f;
        Active = true;
    }

    public override void Exit()
    {
        Debug.Log("Exit : Idle");
        Active = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Active)
        {
            curTime += Time.deltaTime;
            if(curTime > 1.0f)
            {
                enemyStateMachine.ChangeState(StateType.Patrol);
            }
        }
    }
}
