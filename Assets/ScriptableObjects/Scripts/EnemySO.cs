using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "NewEnemyData")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public float Speed { get; set; }
}
