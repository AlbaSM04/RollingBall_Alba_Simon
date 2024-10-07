using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bola : MonoBehaviour
{
    [SerializeField]Vector3 direccion=new Vector3 (0,0,0);
    [SerializeField] float velocidad, fuerzaSalto, fuerzaX;
    private float h;
    private float v;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        h = Input.GetAxisRaw("horizontal");
        v = Input.GetAxisRaw("vertical");
       
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, fuerzaSalto, 0, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce (h, 0, v, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy (other.gameObject);
    }
}
