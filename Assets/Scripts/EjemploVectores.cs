using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploVectores : MonoBehaviour
{
    [SerializeField] Vector3 direccion = new Vector3 (3, 0, 0);
    [SerializeField] int velocidad = 6;
    float tiempo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo > 0 && tiempo < 5)
        {
            transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        }
        else
        {
            direccion = direccion * -1f;
            tiempo = 0f;
        }

        
    }
}
