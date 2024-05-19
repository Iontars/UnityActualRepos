using System;
using UnityEngine;

namespace Rocket_1.Scripts
{
    public class Target : MonoBehaviour
    {
        public static Action<GameObject> OnSpawn3dTarget;
        private float _playerSpeed = 20f;
        private float _xAxis, _yAxis;
    
        void Start()
        {
            OnSpawn3dTarget?.Invoke(gameObject);
        }

        void Update()
        {
            _xAxis = Input.GetAxis("Horizontal");
            _yAxis = Input.GetAxis("Vertical");
            transform.Translate(_xAxis * (_playerSpeed * Time.deltaTime),
                _yAxis * (_playerSpeed * Time.deltaTime), 0);
        }
    }
}