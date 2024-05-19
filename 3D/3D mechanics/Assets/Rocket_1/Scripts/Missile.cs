using UnityEngine;

namespace Rocket_1.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Missile : MonoBehaviour 
    {
        public Transform targetPosition;
        private Rigidbody _rigidbody;
        private float _rocketSpeed = 3f;
        private float _rocketRotateSpeed = 100f;
        private bool _isLaunch;
        
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (targetPosition)
            {
                Vector3 direction = targetPosition.position - _rigidbody.position;
                direction.Normalize();
                Vector3 amountToRotate = Vector3.Cross(direction, transform.up) * Vector3.Angle(transform.up, direction);
                amountToRotate.Normalize();
                _rigidbody.angularVelocity = -amountToRotate * _rocketRotateSpeed;
                _rigidbody.velocity = transform.up * _rocketSpeed;
            }
        }

        private void InitialTarget(GameObject targetGO)
        {
            targetPosition = targetGO.GetComponent<Transform>();
            print(targetPosition);
        }

        private void OnEnable()
        {
            Target.OnSpawn3dTarget += InitialTarget;
        }

        private void OnDisable()
        {
            Target.OnSpawn3dTarget -= InitialTarget;
        }
    }
}