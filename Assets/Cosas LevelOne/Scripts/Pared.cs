using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rbs;

    private float timer = 0f;
    private bool tiempo = false;
    

    void Start()
    {

    }

    
    private void Update()
    {

        if (tiempo)
        {
            timer += 1 * Time.unscaledDeltaTime;
            if (timer >= 2)
            {
                Time.timeScale = 1f;
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].useGravity = true;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            Time.timeScale = 0.1f;
            tiempo = true;
        }
    }
}
