using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bola : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] float velocidad = 10f;
    private float h;  // Movimiento horizontal (X)
    private float v;  // Movimiento vertical (Z)

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
        // Los ejes deben estar invertidos para que "W" mueva hacia adelante en Z y "A" mueva a la izquierda en X
        h = Input.GetAxisRaw("Horizontal"); // Movimiento en X: "A" y "D" para izquierda/derecha
        v = Input.GetAxisRaw("Vertical");   // Movimiento en Z: "W" y "S" para adelante/atrás

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DetectarSuelo())  // Verifica si la bola está en el suelo antes de saltar
            {
                rb.AddForce(0, fuerzaSalto, 0, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        // Aplica la fuerza de movimiento, usa los ejes correctamente
        rb.AddForce(new Vector3(h, 0, v) * velocidad, ForceMode.Force);
    }

    bool DetectarSuelo()
    {
        // Verifica si la bola está tocando el suelo
        return Physics.Raycast(transform.position, Vector3.down, distanciaDeteccionSuelo, queEsSuelo);
    }
}
    
