using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltX.Managers
{
    public class PaintManager : MonoBehaviour
    {
        #region ///Properties
        private static Material selectedPaintMaterial;
        private static Material blockPaintMaterial;
        #endregion
        #region ///Property Methods
        public static Material GetBlockPaintMaterial()
        {
            return blockPaintMaterial;
        }

        public void SetBlockPaintMaterial(Material value)
        {
            blockPaintMaterial = value;
        }
        public static Material GetSelectedPaintMaterial()
        {
            return selectedPaintMaterial;
        }

        public void SetSelectedPaintMaterial(Material value)
        {
            selectedPaintMaterial = value;
        }
        #endregion
        #region ///Manager Functions
        public static void ApplyColor()
        {
            GetBlockPaintMaterial();
            Debug.Log("Material Applied...");
        }
        #endregion

    }
}