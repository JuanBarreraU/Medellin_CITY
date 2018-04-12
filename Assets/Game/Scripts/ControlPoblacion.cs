using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPoblacion : MonoBehaviour 
{
	public int cantidadPersonas;
	public Text textoCantidadPersonas;

	// Use this for initialization
	void Start () 
	{
		cantidadPersonas = 1;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		ActualizarTextoCantidadPersonas ();
		if (cantidadPersonas == 1000) 
		{
			GameObject canvasPropiedades = GameObject.FindGameObjectWithTag ("CanvasPrincipal");
			canvasPropiedades.GetComponent<ControlObjetivos> ().Objetivo [3] = true;
		}
	}

	public void AumentarCantidadPersonas(int cantidad)
	{
		cantidadPersonas += cantidad;
	}

	public void ActualizarTextoCantidadPersonas()
	{
		textoCantidadPersonas.text = cantidadPersonas.ToString ();
	}

}
