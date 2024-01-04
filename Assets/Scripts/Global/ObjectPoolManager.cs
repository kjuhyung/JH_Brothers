using System.Collections;
using UnityEngine;

public enum ObjectPoolType
{
    Bomb,
    Enemy
}

public class ObjectPoolManager : CustomSingleTon<ObjectPoolManager>
{ 
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
            _poolingQueue[i] = new Queue();

            for (int j = 0; j< count; j++)
            {                
                GameObject obj = Instantiate(_poolObject[i]);
                obj.SetActive(false);
                obj.transform.parent = this.transform;
                _poolingQueue[i].Enqueue(obj);
            }
        }
    }

    public GameObject GetGameObject(ObjectPoolType poolType)
    {
        GameObject select = null;

        if (_poolingQueue[(int)poolType].Count == 0)
        {
            select = Instantiate(_poolObject[(int)poolType]);
            select.SetActive(false);
            select.transform.parent = this.transform;

            return select;
        }

        select = (GameObject)_poolingQueue[(int)poolType].Dequeue();

        return select;
    }

    public void ReturnObject(GameObject _obj, ObjectPoolType poolType)
    {
        _poolingQueue[(int)poolType].Enqueue(_obj);
    }
}
