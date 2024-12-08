using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyNPC : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private List<Transform> _wayPoints;
        [SerializeField] private Gun _gun;


        private EnemyStateMachine _stateMachine;

        public EnemyConfig Config => _config;
        public List<Transform> WayPoints => _wayPoints;

        private void Awake()
        {
            _gun.Initialize();

            _stateMachine = new EnemyStateMachine(this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void LookAtTarget(Transform target, float time)
        {
            StartCoroutine(LookAt(target, time));
        }

        private IEnumerator LookAt(Transform target, float time)
        {
            Vector3 direction = target.position - transform.position;
            float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            float rotatePerLoop = rotateZ / time;
            Debug.Log(rotatePerLoop);

            yield return null;
            //while(time > 0)
            //{
            //    transform.rotation = Quaternion.Euler(0, 0, rotateZ);
            //}
        }
    }
}