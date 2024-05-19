using UnityEngine;

namespace Events.Scripts
{
    public interface IPlayableSet
    {
        public bool IsCanPlay { get; set; }

        public Player.BrickMode GetBrickMode();
        public GameObject GetGameObject();
    }
}