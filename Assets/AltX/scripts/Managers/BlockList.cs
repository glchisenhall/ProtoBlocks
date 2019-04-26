using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AltX.scripts
{
    public class BlockList
    {
        public List<Block> blocks = new List<Block>();
        public Block[] aGameObjects;
        public struct Block
        {
            public GameObject obj;
            public int pegCount;
            public int height;
            public Block(GameObject obj, int pegCount, int height)
            {
                this.obj = obj;
                this.pegCount = pegCount;
                this.height = height;
            }
        }

        public void CreateBlock(GameObject obj, int pegCount, int height)
        {
            // Create new block
            Block b = new Block
            {
                obj = obj,
                pegCount = pegCount,
                height = height
            };
            // Add new block to List
            AddBlockToList(b);
            aGameObjects =  ListBlocks().ToArray();
        }

        void AddBlockToList(Block b)
        {
            blocks.Add(b);
        }

        public List<Block> ListBlocks()
        {
            return blocks;
        }
        public void ClearBlocks()
        {
            aGameObjects = null;
            blocks = new List<Block>();
        }
        public void PegCounter()
        {
            int count = 0;
            if(aGameObjects != null)
            foreach (Block m in aGameObjects)
            {
                count += m.pegCount;
            }
            Debug.Log(count);
        }
    }
}