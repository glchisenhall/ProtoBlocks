using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AltX.scripts.Managers
{
    public class UI_Manager : MonoBehaviour
    {
        private GameObject selectedBlock;
        
        private GameObject baseBlock;
        public GameObject SelectedBlock { get => selectedBlock; set => selectedBlock = value; }
        public GameObject BaseBlock { get => baseBlock; set => baseBlock = value; }

        public GameObject GetBaseBlock()
        {
            return BaseBlock;
        }

        public void SetBaseBlock(GameObject value)
        {
            BaseBlock = value;
            PlaceBase(BaseBlock);
        }

        public GameObject GetSelectedBlock()
        {
            return SelectedBlock;
        }

        public void SetSelectedBlock(GameObject value)
        {
            SelectedBlock = value;
        }

        public static void PlaceBase(GameObject baseBlock)
        {
            BlockSpawnManager.PlaceBaseBlock(baseBlock);
        }
    }
}