using System;
using UnityEngine;

namespace Rocket2D.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        public static Action<GameObject> OnSpawn;
        private float _playerSpeed = 20f;
        private float _xAxis, _yAxis;
    
        void Start()
        {
            OnSpawn?.Invoke(gameObject);
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
