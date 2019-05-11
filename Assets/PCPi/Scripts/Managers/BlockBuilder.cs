
/// <summary>
/// Project: ProtoBlock Builder
/// Made for use in Projects: Unicorn Snake & Protoblocks (...more to come?)
/// Filename: BlockBuilder.cs
/// Created by PCPi & AltX
/// Written by: Gary Chisenhall
/// </summary>
#region /// USING
using UnityEngine;
using UnityEditor;
using System;
#endregion

namespace PCPi.Scripts.Editor
{
    /// <summary>
    /// BlockBuilder Class for ProtoBlock Builder
    /// </summary>
    public class BlockBuilder : MonoBehaviour
    {
        private const string altXPath = "Assets/AltX/scripts/Managers/";
        private static MonoScript contains;
        private static bool exists = false;

        #region /// Static Variables
        private static bool finished = false;
        private static bool prefabCreated = false;
        public static GameObject newPrefab;
        #endregion
        #region /// Constructor
        public static void BuildProtoBlock(
            BlockList.Block b,
            int length,
            int width,
            int height,
            Material material,
            Material highlightedMaterial,
            Vector3 scale,
            float offsetFactor,
            bool isBase)
        {

            BuildBlock(
                b,
                length,
                width,
                height,
                material,
                highlightedMaterial,
                scale,
                offsetFactor,
                isBase);
        }
        #endregion
        /// <summary>
        /// Contruct from Editor Window Values
        /// </summary>
        /// <param name="b"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="material"></param>
        /// <param name="highlightedMaterial"></param>
        /// <param name="scale"></param>
        /// <param name="offsetFactor"></param>
        /// <param name="isBase"></param>
        #region /// Builder
        private static void BuildBlock(
            BlockList.Block b,
            int length,
            int width,
            int height,
            Material material,
            Material highlightedMaterial,
            Vector3 scale,
            float offsetFactor,
            bool isBase)
        {
            Transform newTransform;
            GameObject previousTransform;
            bool prefabCreated = false;
            if (b.pegCount >= 1)
            {
                GameObject obj = new GameObject();
                GameObject newProtoBuild = obj;
                Vector3 offset = new Vector3();
                SetNameOfProtBlock(length, width, height, material, newProtoBuild);
                newProtoBuild.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                previousTransform = obj;
                for (int i = 0; i < length; i++)
                {
                    offset = GetNewStartingOffset(offsetFactor, i);
                    for (int j = 0; j < width; j++)
                    {
                        if (previousTransform != null)
                        {
                            Transform t = Instantiate<Transform>(b.obj.transform, newProtoBuild.transform) as Transform;
                            newTransform = t;
                            t.transform.position = previousTransform.transform.position + offset;
                            
                            FindAltX();

                            if (exists)
                            {
                                AltX.Managers.BlockController bs = t.gameObject.AddComponent<AltX.Managers.BlockController>();
                                GetAltXMaterials(material, highlightedMaterial, bs);
                                bs.offset = offsetFactor;
                            }
                            else
                            {
                                scripts.Managers.BlockSettings bs = t.gameObject.AddComponent<scripts.Managers.BlockSettings>();
                                GetMaterials(material, highlightedMaterial, bs);
                            }
                            if (isBase)
                            {
                                t.tag = "BaseBlock";
                            }
                            else
                            {
                                t.tag = "Block";
                            }
                            previousTransform = newTransform.gameObject;
                        }
                        obj = previousTransform;
                        offset = GetNewRowOffset(offsetFactor, i, j);
                    }
                    if (i == length - 1)
                    {
                        offset = new Vector3(0, 0, 0);
                        for (int k = 0; k < height; k++)
                        {
                            if (height > 1)
                            {
                                offset += new Vector3(0, offsetFactor, 0);
                                Transform t = Instantiate<Transform>(newProtoBuild.transform, newProtoBuild.transform) as Transform;
                                newTransform = t;
                                t.transform.position = newProtoBuild.transform.position + offset;
                                previousTransform = newTransform.gameObject;
                            }
                        }
                    }
                }
                finished = CreatePlacementCollider(scale, newProtoBuild);
                newPrefab = newProtoBuild;
                Debug.Log("Prefab Created = " + prefabCreated);
            }
        }
        #endregion
        private static void GetAltXMaterials(
            Material material, 
            Material highlightedMaterial, 
            AltX.Managers.BlockController bs)
        {
            bs.defaultMaterial = material;
            bs.highlightMaterial = highlightedMaterial;
        }
        private static void GetMaterials(
            Material material,
            Material highlightedMaterial,
            scripts.Managers.BlockSettings bs)
        {
            bs.defaultMaterial = material;
            bs.highlightMaterial = highlightedMaterial;
        }
        private static Vector3 GetNewRowOffset(
            float offsetFactor,
            int i,
            int j)
        {
            Vector3 offset;
            if (i % 2 != 0)
            {
                if (j != 0)
                {
                    offset = new Vector3(0, 0, -offsetFactor);
                }
                else
                {
                    offset = new Vector3(0, 0, -offsetFactor);
                }
            }
            else
            {
                offset = new Vector3(0, 0, offsetFactor);
            }

            return offset;
        }

        private static Vector3 GetNewStartingOffset(
            float offsetFactor,
            int i)
        {
            Vector3 offset;
            if (i % 2 == 0)
            {
                if (i != 0)
                {
                    offset = new Vector3(-offsetFactor, 0, 0);
                }
                else
                {
                    offset = new Vector3(0, 0, 0);
                }
            }
            else
            {
                offset = new Vector3(-offsetFactor, 0, 0);
            }

            return offset;
        }
        private static bool CreatePlacementCollider(
            Vector3 scale,
            GameObject newProtoBuild)
        {
            BoxCollider boxCollider = newProtoBuild.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.size = new Vector3(0.01f, 0.01f, 0.01f);
            boxCollider.transform.localScale = scale;
            boxCollider.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            return true;
        }

        private static void SetNameOfProtBlock(
            int length,
            int width,
            int height,
            Material material,
            GameObject newProtoBuild)
        {
            newProtoBuild.name = material.name.ToString()
                                 + "_"
                                 + length.ToString()
                                 + "x"
                                 + width.ToString()
                                 + "x"
                                 + height.ToString()
                                 + "_protoblock";
        }
        /// <summary>
        /// Locate BlockController in ProtoBlocks Project
        /// </summary>
        private static void FindAltX()
        {
            try
            {
                MonoScript contains = (MonoScript)AssetDatabase.LoadAssetAtPath(altXPath + "BlockController.cs", typeof(MonoScript));
                if (contains != null)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                }
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }
        #region Prefab Creation
        /// <summary>
        /// Create new prefab
        /// </summary>
        /// <param name="newProtoBuild"></param>
        /// <returns></returns>
        public static bool CreatePrefab(GameObject newProtoBuild)
        {
            string localPath = "Assets/PCPi/Prefabs/" + newPrefab.name + ".prefab";

            //Check if the Prefab and/or name already exists at the path
            CheckIfPrefab(localPath);

            if (finished)
            {
                PrefabUtility.SaveAsPrefabAsset(
                    newProtoBuild,
                    localPath, /// Prafab save path
                out prefabCreated);
            }
            finished = false;
            if (prefabCreated)
            {
                Debug.Log("Prefab Created = " + prefabCreated);
                DestroyImmediate(newProtoBuild);
            }
            else
            {
                Debug.Log("Prefab Created = "+ prefabCreated);
            }
            return prefabCreated;
        }
        private static void CheckIfPrefab(string localPath)
        {
            if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
            {
                //Create dialog to ask if User is sure they want to overwrite existing Prefab
                if (EditorUtility.DisplayDialog("Are you sure?",
                    "This ProtoBlock Prefab already exists. Do you want to overwrite it?",
                    "Yes",
                    "No"))
                //If the user presses the yes button, create the Prefab
                {
                    return;
                }
            }
            //If the name doesn't exist, create the new Prefab
            else
            {
                Debug.Log(newPrefab.name + " is now a Prefab!");
                return;
            }
        }
        
#endregion

    }
}
