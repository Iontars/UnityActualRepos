using UnityEngine;

namespace _2d_move.Scripts
{
    /// <summary> </summary>
    public class EventManager : MonoBehaviour
    {
        public bool IsUnlockWhiteMap { get; private set; } = false;
        public bool IsUnlockCrossroadGreenMap { get; private set; } = false;

        public void UnlockWhiteMap() => IsUnlockWhiteMap = true;
        public void LockWhiteMap() => IsUnlockWhiteMap = false;

        public void UnlockCrossroadGreenMap() => IsUnlockCrossroadGreenMap = true;
        public void LockCrossroadGreenMap() => IsUnlockCrossroadGreenMap = false;
    }
}
