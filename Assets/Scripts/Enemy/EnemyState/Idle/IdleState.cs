using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        enemyController.body.velocity = Vector2.zero;
        Invoke("Exit", 1f);
        Active = true;
    }

    public override void Exit()
    {
        if (Active)
        {
            Active = false;
            enemyStateMachine.ChangeState(StateType.Patrol);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
