using UnityEngine;
using System;

namespace Events.Scripts
{
    public class Player : MonoBehaviour, IPlayableSet
    {
        public static Action OnSetBounceMode;
        
        private float _playerSpeed = 20f;
        private float _xAxis, _yAxis;
        public enum BrickMode
        {
            Bounce, Frozen
        }
        public bool IsCanPlay { get; set; }
        public BrickMode brickMode;
        
        private void Awake()
        {
            brickMode = BrickMode.Bounce;
        }  

        void Start()
        {
        
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (brickMode == BrickMode.Bounce)
                {
                    brickMode = BrickMode.Frozen;
                }
                else if (brickMode == BrickMode.Frozen)
                {
                    brickMode = BrickMode.Bounce;
                    OnSetBounceMode?.Invoke();
                }
            }
            
            _xAxis = Input.GetAxis("Horizontal");
            _yAxis = Input.GetAxis("Vertical");
            transform.Translate(_xAxis * (_playerSpeed * Time.deltaTime),
                _yAxis * (_playerSpeed * Time.deltaTime), 0);
        }

        public BrickMode GetBrickMode()
        {
            return brickMode;
        }
    }
}
