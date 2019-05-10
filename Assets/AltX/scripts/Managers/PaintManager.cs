using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltX.Managers
{
    public class PaintManager
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

        public static void SetBlockPaintMaterial(Material value)
        {
            blockPaintMaterial = value;
        }
        public static Material GetSelectedPaintMaterial1()
        {
            return selectedPaintMaterial;
        }

        public static void SetSelectedPaintMaterial1(Material value)
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