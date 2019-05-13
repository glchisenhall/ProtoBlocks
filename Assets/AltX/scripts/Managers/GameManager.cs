
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
        private void Update()
        {
            BlockController blockController;
            GameObject obj;
            bool isBase;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                obj = hit.transform.gameObject;
                blockController = obj.GetComponent<BlockController>();
                isBase = (bool)blockController.GetBaseValue();
                //Debug.Log("HIT!!, No really take one!...");
                if (Input.GetMouseButtonDown(1) && hit.collider != null)
                {
                    if (!isBase)
                    {
                        BlockSpawnManager.BlockDestruct(hit.collider.gameObject);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}

