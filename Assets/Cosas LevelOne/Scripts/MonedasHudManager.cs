using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonedasHudManager : MonoBehaviour
{
    [SerializeField] GameObject sinMonedas;
    [SerializeField] GameObject unaMoneda;
    [SerializeField] GameObject dosMonedas;
    [SerializeField] GameObject tresMonedas;  

    private int contadorMonedas = 0;  

    public void SumarMoneda()
    {
        contadorMonedas++; 
        

        
        switch (contadorMonedas)
        {
            case 1:
                sinMonedas.SetActive(false);
                unaMoneda.SetActive(true);  
                break;
            case 2:
                
                dosMonedas.SetActive(true); 
                break;
            case 3:
                tresMonedas.SetActive(true);
                break;
            default:
                break;
        }
    }
}
