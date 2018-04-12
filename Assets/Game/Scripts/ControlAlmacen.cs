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
	
	// Update is called once per frame
	void Update () 
	{
		
		ActualizarTextos ();
		ActualizarCantidadMateriales ();

	}

	public void ActualizarTextos()
	{
		for (int i = 0; i < textoCantMateriales.Length; i++) 
		{
			textoCantMateriales [i].text = cantMateriales [i].ToString();
			
		}
		textoCantMaterialesAlmacen.text = cantTotalMateriales + "/" + cantMaximaMateriales;


	}

	public void ActualizarCantidadMateriales()
	{
		
		cantTotalMateriales = (cantMateriales [0] + cantMateriales [1] + cantMateriales [2]);

			
			

	}

	public void OnMouseDown()
	{
		panelAlmacen.SetActive (true);
	}


}
