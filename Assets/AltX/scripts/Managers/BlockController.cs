using PCPi.scripts.Managers;
using UnityEngine;

namespace AltX.scripts.Managers
{
    /// <summary>
    /// BlockController Class
    /// </summary>
    public class BlockController : BlockSettings
    {
        private void OnMouseDown()
        {
            BlockSpawnManager.PlaceSelectedBlock(BlockToSpawn, transform.position + transform.position, transform);
        }
        /// <summary>
        /// Activates highlighter material & assigns block to spawn
        /// </summary>
        private void OnMouseEnter()
        {
            if (BlockManager)
            {
                BlockToSpawn = BlockManager.GetComponent<BlockManager>().GetSelectedBlock();
            }
            gameObject.GetComponent<Renderer>().material = highlightMaterial;
        }
        /// <summary>
        /// Deactivates highlighter material
        /// </summary>
        private void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}