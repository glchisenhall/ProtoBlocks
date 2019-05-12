/// <summary>
/// Project: ProtoBlock Builder
/// Made for use in Projects: Unicorn Snake & Protoblocks (...more to come?)
/// Filename: BlockSettings.cs
/// Created by PCPi & AltX
/// Written by: Gary Chisenhall & Topher Lee
/// </summary>
#region /// USING
using UnityEngine;
#endregion
namespace PCPi.scripts.Managers
{
    /// <summary>
    /// BlockSettings Class for ProtoBlock Builder
    /// </summary>
    public class BlockSettings : MonoBehaviour
    {
        BlockManager BlockManager;
        AltX.Managers.GameManager gameManager;

        #region /// Constants
        private const string MANAGER_PATH = "/PCPi/Prefabs/Managers/ProtoBlockSceneManager.prefab";
        #endregion
        #region /// Local Variables
        private Color blockColor;
        private GameObject blockSurface;
        private Material paintedMaterial;
        #endregion
        #region /// Global Variables
        public GameObject BlockToSpawn;
        public Material defaultMaterial;
        public Material highlightMaterial;

        public Material PaintedMaterial { get => paintedMaterial; set => paintedMaterial = value; }
        #endregion
        void Start()
        {
            BlockManager = (BlockManager)Resources.Load(MANAGER_PATH);
            if (!BlockManager)
            {
                //Instantiate(BlockManager);
            }
            else
            {
                /// Do nothing
            }
            defaultMaterial = gameObject.GetComponent<Renderer>().material;
        }

    }
}
