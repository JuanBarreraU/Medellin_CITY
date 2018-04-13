using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotonMejoras : MonoBehaviour
{
    public bool activarMejora;
    public GameObject canvasMejora;
    
    

	// las mejoras inician inactivas.
	void Start ()
    {
        activarMejora = false;
        
        
	}
	

	//Si se llama esta funcion se da la informacion de que se puede activar la mejora.
    public void ActivarMejora()
    {
        canvasMejora.SetActive(true);
    }

	//Si se llama esta funcion se elige una de las casas en la escena al azar y esta pedirá que se le realize una mejora.
    public void RealizarMejora()
    {
        
        GameObject canvas = GameObject.FindGameObjectWithTag("CanvasPrincipal");
        GameObject go = GameObject.Instantiate(canvas.GetComponent<ControlMejoras>().casasLvl2[Random.Range(0, canvas.GetComponent<ControlMejoras>().casasLvl2.Length)],transform.position, Quaternion.Euler(-90,0,0));
		print(go.name);
        this.gameObject.SetActive(false);
    }
}
