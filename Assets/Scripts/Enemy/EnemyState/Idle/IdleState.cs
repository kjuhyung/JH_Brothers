using Unity.VisualScripting;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        enemyStateMachine.body.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        
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
