using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRio : MonoBehaviour 
{
	public Material[] materialesRio;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		cambiarMaterialRio ();
	}

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
