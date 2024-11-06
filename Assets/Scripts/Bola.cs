using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bola : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] float velocidad = 10f; 
    private float h; 
    private float v; 

    [Header("Salto")]
    [SerializeField] float fuerzaSalto = 5f; 
    [SerializeField] float distanciaDeteccionSuelo = 1.1f; 
    [SerializeField] LayerMask queEsSuelo; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal"); // h = 1 (D o →), h = -1 (A o ←), h = 0 (sin entrada)
        v = Input.GetAxisRaw("Vertical");   // v = 1 (W o ↑), v = -1 (S o ↓), v = 0 (sin entrada)

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DetectarSuelo())
            {
                rb.AddForce(0, fuerzaSalto, 0, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(h, 0, v) * velocidad, ForceMode.Force);
    }

    bool DetectarSuelo()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanciaDeteccionSuelo, queEsSuelo);
    }
}
    
