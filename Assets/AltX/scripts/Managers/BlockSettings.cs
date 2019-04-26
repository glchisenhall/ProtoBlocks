using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AltX.scripts.Managers
{
    public class BlockSettings : MonoBehaviour
    {
        UI_Manager UI_Manager;
        public GameObject BlockToSpawn;
        public Color blockColor;
        public GameObject blockSurface;

        //[HideInInspector]
        public Material defaultMaterial;
        //[HideInInspector]
        public Material highlightMaterial;



        // Start is called before the first frame update
        void Start()
        {
            UI_Manager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
            defaultMaterial = gameObject.GetComponent<Renderer>().material;
        }

        private void OnMouseDown()
        {
            BlockSpawnManager.PlaceSelectedBlock(BlockToSpawn, transform.position, transform);
        }

        // Update is called once per frame
        void Update()
        {
        }
        /// <summary>
        /// Block Highlight Material Swapper
        /// </summary>
        private void OnMouseEnter()
        {
            BlockToSpawn = UI_Manager.GetSelectedBlock();
            gameObject.GetComponent<Renderer>().material = highlightMaterial;
            //blockPegs.GetComponent<Renderer>().material = highlightMaterial;
        }
        private void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
            //blockPegs.GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}
