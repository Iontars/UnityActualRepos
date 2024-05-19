using System;
using UnityEngine;

namespace Rocket2D.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(Collider2D))]
    public class RocketMovement : MonoBehaviour
    {
        public Transform targetPosition;
        private Rigidbody2D _rigidbody2D;
        private float _rocketSpeed = 3f;
        private float _rocketRotateSpeed = 100f;
        private bool _isLaunch;
        
        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (targetPosition)
            {
                Vector2 rocketDirection = (Vector2)targetPosition.position - _rigidbody2D.position;
                rocketDirection.Normalize();
                float rotateAmount = Vector3.Cross(rocketDirection, transform.up).z;
                _rigidbody2D.angularVelocity = -rotateAmount * _rocketRotateSpeed;
                _rigidbody2D.velocity = transform.up * _rocketSpeed;
            }
        }

        private void InitialTarget(GameObject targetGO)
        {
            this.targetPosition = targetGO.GetComponent<Transform>();
        }

        private void OnEnable()
        {
            PlayerMovement.OnSpawn += InitialTarget;
        }

        private void OnDisable()
        {
            PlayerMovement.OnSpawn -= InitialTarget;
        }
    }
}
