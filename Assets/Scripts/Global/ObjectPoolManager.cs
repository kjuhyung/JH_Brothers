using System.Collections;
using UnityEngine;

public class ObjectPoolManager : CustomSingleTon<ObjectPoolManager>
{
    public enum ObjectPoolType
    {
        Bomb,
        Enemy
    }

    [SerializeField] private GameObject[] _poolObject;

    private Queue[] _poolingQueue;

    private void Awake()
    {
        Initalize(5);
    }

    private void Initalize(int count)
    {
        _poolingQueue = new Queue[_poolObject.Length];
        
        for (int i = 0; i < _poolObject.Length; i++)
        {
            for (int j = 0; j< count; j++)
            {
                _poolingQueue[i].Enqueue(_poolObject[i]);
            }
        }
    }

    public GameObject GetGameObject(ObjectPoolType poolType)
    {
        GameObject select = null;

        select = (GameObject)_poolingQueue[(int)poolType].Dequeue();

        return select;
    }

    public void ReturnObject(GameObject _obj, ObjectPoolType poolType)
    {
        _poolingQueue[(int)poolType].Enqueue(_obj);
    }
}
