using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public MoveStateConfig MoveStateConfig;
        [field: SerializeField] public ShootStateConfig ShootStateConfig;
    }
}