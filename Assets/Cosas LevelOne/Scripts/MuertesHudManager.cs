using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuertesHudManager : MonoBehaviour
{
    [SerializeField] GameObject sinMuertes;
    [SerializeField] GameObject unaMuerte;
    [SerializeField] GameObject dosMuertes;
    [SerializeField] GameObject tresMuertes;  

    private int contadorMuertes = 0;  

    public void SumarMuertes()
    {
        contadorMuertes++; 
                
        switch (contadorMuertes)
        {
            case 1:
                sinMuertes.SetActive(false);
                unaMuerte.SetActive(true);  
                break;
            case 2:
                
                dosMuertes.SetActive(true); 
                break;
            case 3:
                tresMuertes.SetActive(true);
                break;
            default:
                break;
        }
    }
}
