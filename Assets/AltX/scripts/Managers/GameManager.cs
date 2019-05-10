using AltX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltX.Manager
{
    public class GameManager : MonoBehaviour
    {
        UIManager uiManager;
        public bool isBuildMode;
        public bool isPaintMode;
        // Start is called before the first frame update
        void Start()
        {
            CheckMode();
        }
        public void CheckMode()
        {
            if (isBuildMode)
            {
                isPaintMode = false;
            }
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}

