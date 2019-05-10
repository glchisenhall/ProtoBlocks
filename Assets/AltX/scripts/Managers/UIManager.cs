using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AltX.Manager
{
    public class UIManager : MonoBehaviour
    {
        private GameObject selectedBlock;
        private GameObject baseBlock;
        public Material selectedPaintMaterial;

        public GameObject SelectedBlock { get => selectedBlock; set => selectedBlock = value; }
        public GameObject BaseBlock { get => baseBlock; set => baseBlock = value; }
        public Material SelectedPaintMaterial { get => selectedPaintMaterial; set => selectedPaintMaterial = value; }
        public Material BlockPaintMaterial;


        // Base Blocks
        public GameObject GetBaseBlock()
        {
            return BaseBlock;
        }

        public void SetBaseBlock(GameObject value)
        {
            BaseBlock = value;
            PlaceBase(BaseBlock);
        }
        public static void PlaceBase(GameObject baseBlock)
        {
            BlockSpawnManager.PlaceBaseBlock(baseBlock);
        }
        // Blocks
        public GameObject GetSelectedBlock()
        {
            return SelectedBlock;
        }

        public void SetSelectedBlock(GameObject value)
        {
            SelectedBlock = value;
        }
        // Material Painter
        public Material GetSelectedPaintMaterial()
        {
            return BlockPaintMaterial;
        }
        public void SetSelectedPaintMaterial(Material value)
        {
            selectedPaintMaterial = value;
        }
    }
}