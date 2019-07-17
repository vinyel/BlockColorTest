using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachColor : MonoBehaviour
{
    public GameObject ColorPickedPrefab;
    private Material mat;
    private bool isPaint = false;
    private ColorPickerTriangle CP;
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        go = ColorPickedPrefab;
        CP = go.GetComponent<ColorPickerTriangle>();
    }

    // Update is called once per frame
    void Update()
    {
        //CP.SetNewColor(mat.color);
        mat.color = CP.TheColor;   
    }

}
