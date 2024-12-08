using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private MoveStateConfig _moveStateConfig;

        public MoveStateConfig MoveStateConfig => _moveStateConfig;
    }
}