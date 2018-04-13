using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRio : MonoBehaviour 
{
	public Material[] materialesRio;

	
	//Se llama la funcion cambiarMaterialRio para mantener actualizado el color del rio de la ciudad.
	void Update () 
	{
		cambiarMaterialRio ();
	}

	//Al llamarse esta funcion si la cantidad de contaminacion es mayor a 80, el rio cambia de Material para verse sucio y contaminado.
	public void cambiarMaterialRio()
	{
		GameObject canvas = GameObject.FindGameObjectWithTag ("CanvasPrincipal");
		if (canvas.GetComponent<ControlContaminacion> ().cantidadContaminacion > 80f) 
		{
			print ("cambiar");
			this.GetComponent<Renderer> ().material = materialesRio [1];
		} 
		else 
		{
			this.GetComponent<Renderer> ().material = materialesRio [0];
		}
	}
}
