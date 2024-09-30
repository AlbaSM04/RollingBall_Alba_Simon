using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EjemploVectores2 : MonoBehaviour
{
    [SerializeField] Vector3 direccionGiro = new Vector3(0, 3, 0);
    [SerializeField] int velocidadGiro = 6;
    float tiempo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo < 1)
        {
            transform.Rotate(direccionGiro * velocidadGiro * Time.deltaTime);
        }
    }
}
