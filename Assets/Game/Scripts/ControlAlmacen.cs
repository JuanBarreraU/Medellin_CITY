using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlAlmacen : MonoBehaviour 
{
	public int[] cantMateriales;
	public int cantTotalMateriales;
	public int cantMaximaMateriales;
	public Text[] textoCantMateriales;
	public Text textoCantMaterialesAlmacen;
	public GameObject panelAlmacen;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// se llama la funcion ActualizarTextos para mantener actualizados los textos del almacen.
	//se llama la funcion ActualizarCantidadMateriales para mantener actualizada la cantidad de materiales en el almacen.
	void Update () 
	{
		
		ActualizarTextos ();
		ActualizarCantidadMateriales ();

	}

	//Si se llama esta funcion se actualizan los textos del almacen.
	public void ActualizarTextos()
	{
		for (int i = 0; i < textoCantMateriales.Length; i++) 
		{
			textoCantMateriales [i].text = cantMateriales [i].ToString();
			
		}
		textoCantMaterialesAlmacen.text = cantTotalMateriales + "/" + cantMaximaMateriales;


	}

	//Al llamar esta funcion se actualizan la cantidad de materiales en el almacen.
	public void ActualizarCantidadMateriales()
	{
		
		cantTotalMateriales = (cantMateriales [0] + cantMateriales [1] + cantMateriales [2]);

	}

	//Si se da click sobre el almacen, se activa el panel que muestra la cantidad de materiales que hay en el almacen.
	public void OnMouseDown()
	{
		panelAlmacen.SetActive (true);
	}


}
