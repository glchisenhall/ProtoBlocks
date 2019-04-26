using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AltX.scripts.Editor
{
    public class BlockEditor : EditorWindow
    {
        bool debugger = false;
        BlockList blockList;

        public Object obj;
        public int pegCount;
        public int height;

        public void Awake()
        {

        }
        [MenuItem("Tools/Block Builder")]
        public static void ShowWindow()
        {
            GetWindow<BlockEditor>("Block Editor");
        }
        void OnGUI()
        {
            GUILayout.Label("Block Builder", EditorStyles.boldLabel);

            pegCount = EditorGUILayout.IntField("Quantity of Pegs", pegCount);
            height = EditorGUILayout.IntField("Height of Block", height);

            obj = EditorGUILayout.ObjectField(obj, typeof(GameObject), true);

            if (GUILayout.Button("Create Block"))
            {
                if (blockList != null)
                {
                    if (obj != null && pegCount > 0)
                        blockList.CreateBlock((GameObject)obj, pegCount, height);
                }
                else
                { 
                    blockList = new BlockList();
                }
            }
            if (GUILayout.Button("Peg Count"))
            {
                if (blockList != null)
                {
                    blockList.PegCounter();
                }
            }
            if (GUILayout.Button("Clear Block List"))
            {
                if(blockList != null)
                {
                    blockList.ClearBlocks();
                    Debug.Log("All Blocks Cleared");
                }
            }
            GUILayout.Label("Debug", EditorStyles.miniBoldLabel);
            if (GUILayout.Toggle(debugger, GUIContent.none))
            {
                debugger = true;
            }
            else
            {
                debugger = false;
            }
            if (blockList != null && debugger)
            {
                GUILayout.Label("Quantity Of Blocks In List", EditorStyles.miniBoldLabel);
                GUILayout.TextArea(blockList.ListBlocks().Count.ToString(), EditorStyles.textArea);
            }

        }
    }
}