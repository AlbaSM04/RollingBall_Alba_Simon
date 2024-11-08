using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : MonoBehaviour
{
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
