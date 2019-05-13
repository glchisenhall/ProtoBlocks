using PCPi.scripts.Managers;
using UnityEngine;

namespace AltX.Managers
{
    /// <summary>
    /// BlockController Class
    /// </summary>
    public class BlockController : BlockSettings
    {
        public static bool isBaseBlock;
        public float offset;
        public GameObject parent;

        public GameObject blockCanvas;

        private void Awake()
        {
            parent = gameObject.GetComponentInParent<Collider>().gameObject;
            isBaseBlock = GetBaseValue();
            blockCanvas.SetActive(false);
        }
        private void OnMouseDown()
        {
            if (GameManager.GetIsBuildMode())
            {
                BlockSpawnManager.PlaceSelectedBlock(BlockToSpawn, transform.position, transform);
            }
            if (GameManager.GetIsPaintMode())
            {
                PaintedMaterial = PaintManager.GetBlockPaintMaterial();
                gameObject.GetComponent<Renderer>().material = PaintedMaterial;
                defaultMaterial = PaintedMaterial;
            }
        }
        /// <summary>
        /// Activates highlighter material & assigns block to spawn
        /// </summary>
        private void OnMouseEnter()
        {
            BlockToSpawn = BlockManager.GetSelectedBlock();
            gameObject.GetComponent<Renderer>().material = highlightMaterial;
            blockCanvas.SetActive(true);
        }
        /// <summary>
        /// Deactivates highlighter material
        /// </summary>
        private void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
            blockCanvas.SetActive(false);
        }
        public bool GetBaseValue()
        {
            if (gameObject.tag == "BaseBlock")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //private void OnDestroy()
        //{
        //    Debug.Log("Error");
        //}
    }
}