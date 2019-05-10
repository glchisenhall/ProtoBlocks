using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PCPi.scripts.Managers;

namespace AltX.Managers
{
    public class BlockSettings : MonoBehaviour
    {

        BlockManager BlockManager;
        GameManager gameManager;
        //public bool isBaseBlock;
        public GameObject BlockToSpawn;
        public Color blockColor;
        public GameObject blockSurface;
        public GameObject blockBody;

        //[HideInInspector]
        public Material defaultMaterial;
        //[HideInInspector]
        public Material highlightMaterial;
        //[HideInInspector]
        public Material paintedMaterial;



        // Start is called before the first frame update
        //public void Start()
        //{
        //    if (gameObject.tag == "BaseBlock")
        //    {
        //        isBaseBlock = true;
        //    }
        //    else
        //    {
        //        isBaseBlock = false;
        //    }
        //    BlockManager = GameObject.Find("ProtoBlockSceneManager").GetComponent<BlockManager>();
        //    defaultMaterial = gameObject.GetComponent<Renderer>().material;
        //}

        //private void OnMouseDown()
        //{
        //    if (Input.GetButtonDown("fire0"))
        //    {

        //    }
        //    if (Input.GetButtonDown("fire1"))
        //    {

        //    }
        //    if (gameManager.isBuildMode)
        //    {
        //        BlockSpawnManager.PlaceSelectedBlock(BlockToSpawn, transform.position, transform);
        //    }
        //    if (gameManager.isPaintMode)
        //    {
        //        blockBody.GetComponent<Renderer>().material = paintedMaterial;
        //    }
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //}
        ///// <summary>
        ///// Block Highlight Material Swapper
        ///// </summary>
        //private void OnMouseEnter()
        //{
        //    BlockToSpawn = BlockManager.GetSelectedBlock();
        //    gameObject.GetComponent<Renderer>().material = highlightMaterial;
        //    //blockPegs.GetComponent<Renderer>().material = highlightMaterial;
        //}
        //private void OnMouseExit()
        //{
        //    gameObject.GetComponent<Renderer>().material = defaultMaterial;
        //    //blockPegs.GetComponent<Renderer>().material = defaultMaterial;
        //}
    }
}
