
using UnityEngine;

namespace AltX.Managers
{
    public class GameManager : MonoBehaviour
    {
        //UIManager uiManager;
        private static bool isBuildMode;
        private static bool isPaintMode;

        public static bool GetIsBuildMode()
        {
            return isBuildMode;
        }

        public void SetIsBuildMode(bool value)
        {
            isBuildMode = value;
        }

        public static bool GetIsPaintMode()
        {
            return isPaintMode;
        }

        public void SetIsPaintMode(bool value)
        {
            isPaintMode = value;
        }
        private void Start()
        {
            isBuildMode = true;
            isPaintMode = false;
        }
    }
}

