using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchilla : MonoBehaviour
{
    [SerializeField] int direccionGiro;
    [SerializeField] int velocidadGiro = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, velocidadGiro * Time.deltaTime, 0);
    }
}
