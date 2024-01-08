using UnityEngine;

public class DashAttackState : AttackState
{
    private float[] attackDeley;
    private float attackSpeed;

    private void Start()
    {
        attackDeley = enemyController.enemyData.AttackDeley;
        attackSpeed = enemyController.enemyData.Speed * 2f;
        Debug.Log(attackDeley);
        Debug.Log(attackSpeed);
    }

    private void Update()
    {
        if (Active)
        {
            Debug.Log(curTime);
            curTime += Time.deltaTime;
            if (curTime > attackDeley[0])
            {
                if(curTime > attackDeley[1])
                {
                    enemyStateMachine.ChangeState(StateType.Idle);
                }

                if(enemyController.direction)
                {
                    enemyController.body.velocity = Vector2.right * attackSpeed;
                }
                else
                {
                    enemyController.body.velocity = (-Vector2.right) * attackSpeed;
                }
            }
        }
    }
}
