using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] Vector3 direccion; // Dirección del movimiento
    [SerializeField] int velocidad = 6; // Velocidad de movimiento

    [Header("Rotación")]
    [SerializeField] float velocidadGiro = 100f; // Velocidad de rotación
    [SerializeField] Vector3 direccionGiro; // Eje de rotación

    float tiempo;
    float cambioDireccionIntervalo = 0.75f; // Intervalo de tiempo para cambiar de dirección

    void Update()
    {
        // Rotación continua sobre el eje especificado
        transform.Rotate(direccionGiro.normalized * velocidadGiro * Time.deltaTime);

        // Movimiento entre dos puntos
        tiempo += Time.deltaTime;
        if (tiempo >= cambioDireccionIntervalo)
        {
            // Cambia la dirección y reinicia el temporizador
            direccion = -direccion;
            tiempo = 0f;
        }

        // Mueve la sierra en la dirección actual
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
    }
}
