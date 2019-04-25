using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelectionManager : MonoBehaviour
{

    public GameObject blockSurface;
    //[HideInInspector]
    public Collider col;
    //[HideInInspector]
    public Material defaultMaterial;
    //[HideInInspector]
    public Material highlightMaterial;

    public Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        col = blockSurface.GetComponent<Collider>();
        defaultMaterial = blockSurface.GetComponent<Renderer>().material;
        trans = transform;
}
    private void OnMouseEnter()
    {
        blockSurface.GetComponent<Renderer>().material = highlightMaterial;
    }
    private void OnMouseExit()
    {
        blockSurface.GetComponent<Renderer>().material = defaultMaterial;
    }
    private void OnMouseDown()
    {
        //BuildManager.PlaceSelectedBlock(trans.y + 2f)
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
