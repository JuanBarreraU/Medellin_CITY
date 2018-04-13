using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlObjetivos : MonoBehaviour 
{
	public GameObject[] imagenCompletado;
	public bool[] Objetivo;
	public int[] cantExpObjetivos;

	// Se utiliza un siclo for para definir que los objeticos se encuentran incompletos.
	// Se utiliza otro siclo for para desactivar las imagenes que indican que los objetivos estan completos.
	void Start () 
	{
		for (int i = 0; i < Objetivo.Length; i++) 
		{
			Objetivo [i] = false;
		}
		for (int i = 0; i < imagenCompletado.Length; i++) 
		{
			imagenCompletado [i].SetActive(false);
		}
	}
	
	// Se llama la funcion CompletarObjetivos paara verificar en que momento se cumple un objetivo.
	void Update () 
	{
		CompletarObjetivos ();
	}

	//Al llamar esta funcion se crea un siclo for para activar la imagen que indica que se cumplio el objetivo correspondiente.
	public void CompletarObjetivos()
	{
		for (int i = 0; i < Objetivo.Length; i++)
		{
			if (Objetivo [i] == true) 
			{
				imagenCompletado [i].SetActive(true);
				this.gameObject.GetComponent<ControlExperiencia> ().AumentarExperiencia (cantExpObjetivos [i]);
				Objetivo[i] = false;

			}
			
		}

	}



	
}
