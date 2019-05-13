/// <summary>
/// Project: ProtoBlock Builder
/// Made for use in Projects: Unicorn Snake & Protoblocks (...more to come?)
/// Filename: SelectionManager.cs
/// Created by PCPi & AltX
/// Written by: Gary Chisenhall
/// </summary>
#region /// USING
using UnityEngine;
using AltX.Managers;
using UnityStandardAssets.CrossPlatformInput;
#endregion
namespace PCPi.scripts.Managers
{
    public class SelectionManager : GameManager
    {
        private InputManager inputManager;

        private void Start()
        {
            inputManager = gameObject.GetComponent<InputManager>();

        }

        public void LateUpdate()
        {
            BlockController blockController;
            GameObject obj;
            bool isBase;
            Ray ray = Camera.main.ScreenPointToRay(CrossPlatformInputManager.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                obj = hit.transform.gameObject;
                blockController = obj.GetComponent<BlockController>();
                isBase = (bool)blockController.GetBaseValue();
                if (CrossPlatformInputManager.GetButton("Fire1") && hit.collider != null)
                {
                    if (GetIsBuildMode())
                    {
                        BlockSpawnManager.PlaceSelectedBlock(blockController.BlockToSpawn, blockController.transform.position, blockController.transform);
                    }
                    if (GetIsPaintMode())
                    {
                        blockController.PaintedMaterial = PaintManager.GetBlockPaintMaterial();
                        blockController.gameObject.GetComponent<Renderer>().material = blockController.PaintedMaterial;
                        blockController.defaultMaterial = blockController.PaintedMaterial;
                    }
                }
                if (CrossPlatformInputManager.GetButton("Fire2") && hit.collider != null)
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