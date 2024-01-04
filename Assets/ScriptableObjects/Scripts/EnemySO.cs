using UnityEngine;

public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float Health { get; set; }
    [field: SerializeField] public float MaxHealth { get; set; }
    [field: SerializeField] public float Speed { get; set; }


}
