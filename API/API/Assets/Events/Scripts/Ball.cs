using UnityEngine;

namespace Events.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public class Ball : MonoBehaviour
    {
        public delegate void BallEventHandler();
        public event BallEventHandler OnBallGone;
        public event BallEventHandler OnBallBounce;
        private Rigidbody2D _rb;
    
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void OnCollisionEnter2D(Collision2D obstacle)
        {
            if (obstacle.gameObject.TryGetComponent<IPlayableSet>(out var obstacleOut ))
            {
                switch (obstacleOut.GetBrickMode())
                {
                    case Player.BrickMode.Bounce: 
                        AddImpulse();
                        UnStickFromCollision();
                        break;
                    case Player.BrickMode.Frozen:
                        StickToCollision(obstacleOut);
                        break;
                }
            }
        }
    
        private void AddImpulse()
        {
            _rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
            UnStickFromCollision();
            OnBallBounce?.Invoke();
        }

        private void StickToCollision(IPlayableSet playable)
        {
            gameObject.transform.parent = playable.GetGameObject().transform;
        }
        private void UnStickFromCollision()
        {
            gameObject.transform.parent = null;
        }
    
    
    
        private void OnEnable()
        {
            Player.OnSetBounceMode += AddImpulse;
        }

        private void OnDisable()
        {
            Player.OnSetBounceMode -= AddImpulse;
            OnBallGone?.Invoke();
        }
    }
}
