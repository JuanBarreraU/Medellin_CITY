using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlConstruccion : MonoBehaviour
{
	public bool ubicado;
	private Color colorCubo;
	public GameObject cubo;

	//la construccion inicia sin estar ubicada en la posicion deseada y se activa un cubo semitrasparente de color verde.
	void Start () 
	{
		ubicado = false;
		ActivarCubo ();
		colorCubo = new Color(0F, 1F, 0F, 0.3F);


		
	}
	
	//si la construccion es ubicada en la posicion deseada el cubo de color verde desaparece.
	void Update () 
	{
		GameObject canvas = GameObject.FindGameObjectWithTag ("CanvasPrincipal");
		
		cubo.GetComponent<MeshRenderer> ().material.color = colorCubo;
		if (ubicado == true && canvas.GetComponent<ControlRemover>().remover == false )
		{
			DesactivarCubo ();
		}

			



	}

	//Si la construccion colisiona con otro objeto con un tag diferente a Building, el cubo se pondrá rojo indicando q no se puede construir ahi.
	public void OnTriggerStay(Collider col)
	{
		if (col.tag != "Building" && ubicado == false) 
		{
			
			colorCubo = new Color(1F, 0F, 0F, 0.3F);
			GameObject camara = GameObject.FindGameObjectWithTag ("Camara");
			camara.GetComponent<ConstruccionPlacement> ().puedeConstruir = false;

		}
	}


	//Si la construccion deja de colisionar el cubo nuevamente será verde indicando que ahi si se puede construir.
	public void OnTriggerExit(Collider col)
	{
		if (col.tag != "Building") 
		{
			colorCubo = new Color(0F, 1F, 0F, 0.3F);
			GameObject camara = GameObject.FindGameObjectWithTag ("Camara");
			camara.GetComponent<ConstruccionPlacement> ().puedeConstruir = true;
		
		}
	}



	public void ActivarCubo()
	{
		cubo.SetActive (true);
	}

	public void DesactivarCubo()
	{
		cubo.SetActive (false);
	}


}
