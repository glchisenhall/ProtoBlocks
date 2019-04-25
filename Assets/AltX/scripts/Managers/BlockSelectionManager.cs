using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AltX
{
    public class BlockSelectionManager : MonoBehaviour
    {
        public Color blockColor;
        public GameObject blockSurface;
        //public GameObject blockTop;
        //[HideInInspector]
        public Collider blockCollider;
        public GameObject blockPegs;
        public GameObject blockBody;

        //[HideInInspector]
        public Material defaultMaterial;
        //[HideInInspector]
        public Material highlightMaterial;

        public Transform trans;

        // Start is called before the first frame update
        void Start()
        {
            blockCollider = blockSurface.GetComponent<Collider>();
            defaultMaterial = blockSurface.GetComponent<Renderer>().material;
            trans = transform;
        }

        private void OnMouseDown()
        {
            //BlockSpawnManager.PlaceSelectedBlock(trans.y + 2f)
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
            blockSurface.GetComponent<Renderer>().material = highlightMaterial;
            blockPegs.GetComponent<Renderer>().material = highlightMaterial;
        }
        private void OnMouseExit()
        {
            blockSurface.GetComponent<Renderer>().material = defaultMaterial;
            blockPegs.GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}
