using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPoblacion : MonoBehaviour 
{
	public int cantidadPersonas;
	public Text textoCantidadPersonas;

	// La cantidad de personas en la ciudad inicia siendo igual a 1.
	void Start () 
	{
		cantidadPersonas = 1;
		
	}
	
	// Se llama la funcion ActualizarTextoCantidadPersonas para mantener  actualizado el texto en pantalla q muestra cuantas personas hay en tu ciudad.
	//Si la cantidad de personas en la ciudad es mayor o igual a mil se cumple uno de los objetivos del juego.
	void Update () 
	{
		ActualizarTextoCantidadPersonas ();
		if (cantidadPersonas >= 1000) 
		{
			GameObject canvasPropiedades = GameObject.FindGameObjectWithTag ("CanvasPrincipal");
			canvasPropiedades.GetComponent<ControlObjetivos> ().Objetivo [3] = true;
		}
	}

	//Al llamar esta funcion la cantidad de personas aumenta segun la cantidad dada como argumento.
	public void AumentarCantidadPersonas(int cantidad)
	{
		cantidadPersonas += cantidad;
	}

	//Al llamar esta funcion se actualiza el texto en pantalla que muestra cuantas personas hay en la ciudad.
	public void ActualizarTextoCantidadPersonas()
	{
		textoCantidadPersonas.text = cantidadPersonas.ToString ();
	}

}
