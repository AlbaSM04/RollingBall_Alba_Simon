using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioSource SFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Sonido(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
