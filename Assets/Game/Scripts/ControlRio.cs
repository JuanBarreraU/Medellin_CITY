using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRio : MonoBehaviour 
{
	public Material[] materialesRio;
	public GameObject canvas;

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
		
		if (canvas.GetComponent<ControlContaminacion>().cantidadContaminacion > 80) 
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
