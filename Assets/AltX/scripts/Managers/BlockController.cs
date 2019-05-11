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
        public static bool isBaseBlock;
        public float offset;
        private GameObject parent;
        private void Awake()
        {
            //BlockManager = GameObject.Find("ProtoBlockSceneManager").GetComponent<BlockManager>();
            //gameManager = BlockManager.GetComponent<GameManager>();
            parent = gameObject.GetComponentInParent<Collider>().gameObject;
            isBaseBlock = GetBaseValue();
        }
        private void OnTriggerEnter(Collider other)
        {
            //if (Input.GetMouseButtonDown(1))
            //{
            //    if (!GetBaseValue())
            //    {
            //        BlockSpawnManager.BlockDestruct(this.GetComponentInChildren<Transform>().gameObject);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
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