using PCPi.scripts.Managers;
using UnityEngine;

namespace AltX.Managers
{
    /// <summary>
    /// BlockController Class
    /// </summary>
    public class BlockController : BlockSettings
    {
        //private BlockManager BlockManager;
        //private GameManager gameManager;
        private bool isBaseBlock;
        public float offset;

        private void Awake()
        {
            //BlockManager = GameObject.Find("ProtoBlockSceneManager").GetComponent<BlockManager>();
            //gameManager = BlockManager.GetComponent<GameManager>();
            GetBaseValue();
        }
        private void OnMouseDown()
        {
            if (GameManager.GetIsBuildMode())
            {
                BlockSpawnManager.PlaceSelectedBlock(BlockToSpawn, transform.position, transform);

                //BlockSpawnManager.PlaceSelectedBlock(BlockToSpawn, transform.position, transform);
            }
            if (GameManager.GetIsPaintMode())
            {
                paintedMaterial = PaintManager.GetBlockPaintMaterial();
                gameObject.GetComponent<Renderer>().material = paintedMaterial;
                defaultMaterial = paintedMaterial;
            }
        }
        /// <summary>
        /// Activates highlighter material & assigns block to spawn
        /// </summary>
        private void OnMouseEnter()
        {
            BlockToSpawn = BlockManager.GetSelectedBlock();
            gameObject.GetComponent<Renderer>().material = highlightMaterial;
        }
        /// <summary>
        /// Deactivates highlighter material
        /// </summary>
        private void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
        }
        private void GetBaseValue()
        {
            if (gameObject.tag == "BaseBlock")
            {
                isBaseBlock = true;
            }
            else
            {
                isBaseBlock = false;
            }
        }
    }
}