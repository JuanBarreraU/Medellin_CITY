using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotonMejoras : MonoBehaviour
{
    public bool activarMejora;
    public GameObject canvasMejora;
    
    

	// Use this for initialization
	void Start ()
    {
        activarMejora = false;
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void ActivarMejora()
    {
        canvasMejora.SetActive(true);
    }

    public void RealizarMejora()
    {
        
        GameObject canvas = GameObject.FindGameObjectWithTag("CanvasPrincipal");
        GameObject go = GameObject.Instantiate(canvas.GetComponent<ControlMejoras>().casasLvl2[Random.Range(0, canvas.GetComponent<ControlMejoras>().casasLvl2.Length)],transform.position, Quaternion.Euler(-90,0,0));
		print(go.name);
        this.gameObject.SetActive(false);
    }
}
