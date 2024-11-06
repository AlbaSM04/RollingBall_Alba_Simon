using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] Vector3 direccion; // Direcci�n del movimiento
    [SerializeField] int velocidad = 6; // Velocidad de movimiento

    [Header("Rotaci�n")]
    [SerializeField] float velocidadGiro = 100f; // Velocidad de rotaci�n
    [SerializeField] Vector3 direccionGiro; // Eje de rotaci�n

    float tiempo;
    float cambioDireccionIntervalo = 0.75f; // Intervalo de tiempo para cambiar de direcci�n

    void Update()
    {
        // Rotaci�n continua sobre el eje especificado
        transform.Rotate(direccionGiro.normalized * velocidadGiro * Time.deltaTime);

        // Movimiento entre dos puntos
        tiempo += Time.deltaTime;
        if (tiempo >= cambioDireccionIntervalo)
        {
            // Cambia la direcci�n y reinicia el temporizador
            direccion = -direccion;
            tiempo = 0f;
        }

        // Mueve la sierra en la direcci�n actual
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
    }
}
