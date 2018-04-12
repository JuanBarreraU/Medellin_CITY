using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlConstruccion : MonoBehaviour 
{
	public bool ubicado;
	private Color colorCubo;
	public GameObject cubo;

	// Use this for initialization


		
	void Start () 
	{
		ubicado = false;
		cubo.SetActive (true);
		colorCubo = new Color(0F, 1F, 0F, 0.3F);


		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		cubo.GetComponent<MeshRenderer> ().material.color = colorCubo;
		if (ubicado == true)
		{
			cubo.SetActive (false);
		}



	}

	public void OnTriggerStay(Collider col)
	{
		if (col.tag != "Building" && ubicado == false) 
		{
			
			colorCubo = new Color(1F, 0F, 0F, 0.3F);
			GameObject camara = GameObject.FindGameObjectWithTag ("Camara");
			camara.GetComponent<ConstruccionPlacement> ().puedeConstruir = false;

		}
	}

	public void OnTriggerExit(Collider col)
	{
		if (col.tag != "Building") 
		{
			colorCubo = new Color(0F, 1F, 0F, 0.3F);
			GameObject camara = GameObject.FindGameObjectWithTag ("Camara");
			camara.GetComponent<ConstruccionPlacement> ().puedeConstruir = true;
		
		}
	}
}
