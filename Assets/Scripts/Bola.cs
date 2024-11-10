using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    [SerializeField] GameObject camaraPrincipal;
    [SerializeField] GameObject camaraLateral;

    [Header("Posicion inicial")]
    [SerializeField] Vector3 reaparicion;


    [Header("Monedas")]
    [SerializeField] MonedasHudManager monedasHudManager;
    
    [Header("Muerte")]
    [SerializeField] MuertesHudManager muertesHudManager;

    [Header("Canvas")]
    [SerializeField] Canvas revivir;
    [SerializeField] Canvas ganador;
    [SerializeField] Canvas hud;

    [Header("Audio")]
    [SerializeField] AudioManager manager;
    [SerializeField] AudioClip muerte;
    
    
    

    Rigidbody rb;

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

        if (saludActual <= 0)
        {
            manager.Sonido(muerte);

            if (contadorMuertes <= 2)
            {
                Reaparecer();
                contadorMuertes++;  
                muertesHudManager.SumarMuertes();  
                saludActual = saludMaxima;  
            }
            else
            {
                hud.gameObject.SetActive(false);  
                revivir.gameObject.SetActive(true); 
                Destroy(gameObject);  
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
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("SueloToxico"))
        {
            manager.Sonido(muerte);
            Reaparecer();
            muertesHudManager.SumarMuertes();
            saludActual = saludMaxima;
            camaraLateral.SetActive(false);
            camaraPrincipal.SetActive(true);

        }
        
        if (other.gameObject.CompareTag("Sierra"))
        {
            saludActual = saludActual - cantidadDaño;                  
        }
        
        if (other.gameObject.CompareTag("Cuchilla"))
        {
            saludActual = saludActual - cantidadDaño;                  
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
        
        if (other.gameObject.CompareTag("Potencidor"))
        {
            velocidad += 3;
        }
        
        if (other.gameObject.CompareTag("DesPotenciador"))
        {
            velocidad -= 3;
        }
        
        if (other.gameObject.CompareTag("Ganar"))
        {
            hud.gameObject.SetActive(false);
            ganador.gameObject.SetActive(true);
        }        
    }

    private void Reaparecer()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.position = reaparicion;

        rb.isKinematic = false;         
    }

     
}
    
