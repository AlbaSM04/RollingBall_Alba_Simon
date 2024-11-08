using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] Vector3 direccion;
    [SerializeField] int velocidad = 6;
    float tiempo;
    float cambioDireccionIntervalo = 0.75f;

    [Header("Configuración de Rotación")]
    [SerializeField] float tiempoEntreGiros = 3f; 
    [SerializeField] float velocidadGiro = 180f; 
    [SerializeField] Vector3 ejeGiro = Vector3.up; 

    private float tiempoRestante; 
    private bool girando = false; 
    private float anguloGiroPendiente = 0f; 
    void Start()
    {
        tiempoRestante = tiempoEntreGiros; 
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= cambioDireccionIntervalo)
        {

            direccion = -direccion;
            tiempo = 0f;
        }


        transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);

        if (!girando)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0f)
            {
                girando = true;
                anguloGiroPendiente = 180f; 
                tiempoRestante = tiempoEntreGiros; 
            }
        }

        if (girando)
        {
            float giroFrame = velocidadGiro * Time.deltaTime;

            if (giroFrame > anguloGiroPendiente)
            {
                giroFrame = anguloGiroPendiente;
            }

            transform.Rotate(ejeGiro * giroFrame);

            anguloGiroPendiente -= giroFrame;

            if (anguloGiroPendiente <= 0f)
            {
                girando = false;
            }
        }
    }
}
