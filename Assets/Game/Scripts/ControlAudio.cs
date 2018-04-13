using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlAudio : MonoBehaviour 
{
    public AudioMixer masterMixer;
    
    //Se utiliza el audioMixer para controlar el volumen del juego.
	public void MusicSetSound(float soundLevel)
    {
        masterMixer.SetFloat("musicVol", soundLevel);
    }
}
