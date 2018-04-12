using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlObjetivos : MonoBehaviour 
{
	public GameObject[] imagenCompletado;
	public bool[] Objetivo;
	public int[] cantExpObjetivos;

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () 
	{
		CompletarObjetivos ();
	}

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
