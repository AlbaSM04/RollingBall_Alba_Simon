using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] Vector3 direccionGiro = new Vector3(0, 5, 0), direccion = new Vector3(0, 0, 0.5f);
    [SerializeField] float velocidadGiro = 7, velocidad;
    float timer;
    
    void Start()
    {

    }

    
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer < 0.4f)
        {
            transform.Rotate(direccionGiro * velocidadGiro * Time.deltaTime);
            transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
        }
        else
        {
            direccion = direccion * -1;
            timer = 0;
        }
    }
}
