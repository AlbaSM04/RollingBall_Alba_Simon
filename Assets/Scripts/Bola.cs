using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bola : MonoBehaviour
{
    Vector3 direccion=new Vector3 (0,0,0);
    float velocidad;
    void Start()
    {
        
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("horizontal");
        float v = Input.GetAxisRaw("vertical");
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            h = 0;
            v = 1;
            direccion = new Vector3 (h, 0, v);
            transform.Translate
        }
    }
}
