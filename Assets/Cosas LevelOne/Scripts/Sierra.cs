using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] Vector3 direccion; 
    [SerializeField] int velocidad = 6; 

    [Header("Rotación")]
    [SerializeField] float velocidadGiro = 100f; 
    [SerializeField] Vector3 direccionGiro; 

    float tiempo;
    float cambioDireccionIntervalo = 0.75f; 

    void Update()
    {
        
        transform.Rotate(direccionGiro.normalized * velocidadGiro * Time.deltaTime);

        
        tiempo += Time.deltaTime;
        if (tiempo >= cambioDireccionIntervalo)
        {
            
            direccion = -direccion;
            tiempo = 0f;
        }

        
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
    }
}
