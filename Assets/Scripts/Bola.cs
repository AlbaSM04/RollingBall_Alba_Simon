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

    [Header("Configuración de Salud")]
    [SerializeField] int saludMaxima = 100;  
    [SerializeField] int saludActual;
    [SerializeField] int cantidadDaño;
    int contadorMuertes = 0;
    
    [Header("Configuración camaras")]
    [SerializeField] GameObject camaraPrincipal, camaraLateral;

    [Header("Posicion inicial")]
    [SerializeField] Vector3 reaparicion;


    [Header("Monedas")]
    [SerializeField] MonedasHudManager monedasHudManager;
    
    [Header("Muerte")]
    [SerializeField] MuertesHudManager muertesHudManager;




    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        saludActual = saludMaxima;
        camaraLateral.SetActive(false);
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal"); // Movimiento en X: "A" y "D" para izquierda/derecha
        v = Input.GetAxisRaw("Vertical");   // Movimiento en Z: "W" y "S" para adelante/atrás

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DetectarSuelo()) 
            {
                rb.AddForce(0, fuerzaSalto, 0, ForceMode.Impulse);
            }
        }

        if (contadorMuertes < 3)
        {
            if (saludActual <= 0)
            {
                Reaparecer();
                muertesHudManager.SumarMuertes();
                saludActual = saludMaxima;
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

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Bomba"))
        {
            saludActual = saludActual - cantidadDaño;
            Debug.Log(saludActual);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Sierra"))
        {
            saludActual = saludActual - cantidadDaño;
            Debug.Log(saludActual);            
        }
        
        if (other.gameObject.CompareTag("Moneda"))
        {
            monedasHudManager.SumarMoneda();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("CambioCamara"))
        {
            camaraPrincipal.SetActive(false);
            camaraLateral.SetActive(true);           
        }
        
        if (other.gameObject.CompareTag("CambioCamara2"))
        {
            camaraPrincipal.SetActive(true);
            camaraLateral.SetActive(false);
        }
    }

    private void Reaparecer()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.position = reaparicion;

        rb.isKinematic = false;         
    }

    void Muerte()
    {
        Debug.Log("La bola ha sido destruida");
        
        Destroy(gameObject);
    }    
}
    
