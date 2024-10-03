using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bola : MonoBehaviour
{
    Vector3 direccion=new Vector3 (0,0,0);
    float velocidad, fuerzaSalto, fuerzaX;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("horizontal");
        float v = Input.GetAxisRaw("vertical");
       
        transform.position += newVector3

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           rb.AddForce (0, fuerzaSalto, 0 )
        }
    }
}
