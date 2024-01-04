using UnityEngine;

public abstract class BaseState : MonoBehaviour, IState
{
    public abstract void Enter();

    public abstract void Exit();
}
