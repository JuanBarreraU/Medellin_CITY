using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlExperiencia : MonoBehaviour 
{
	public int cantidadExperiencia;
	public int cantidadExperienciaMaxima;
	public Text textoCantidadExperiencia;
	public int nivel;
	public Text textoNivel;
	public GameObject imagenNivel;
	public Sprite[] spritesNiveles;
	public GameObject imagenLvlUp;
	public Text textoLvlUp;

	// Use this for initialization
	void Start () 
	{
		cantidadExperiencia = 0;
		cantidadExperienciaMaxima = 100;
		nivel = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ActualizarTextoNivel ();
		ActualizarTextoEsperiencia ();
		AumentarNivel ();
		ActualizarImagenNivel ();
		
	}

	public void ActualizarTextoNivel()
	{
		textoNivel.text = nivel.ToString ();
	}

	public void ActualizarTextoEsperiencia()
	{
		textoCantidadExperiencia.text = cantidadExperiencia + "/" + cantidadExperienciaMaxima;
	}

	public void AumentarExperiencia(int cantidad)
	{
		cantidadExperiencia += cantidad;
	}

	public void AumentarNivel()
	{
		if (cantidadExperiencia >= cantidadExperienciaMaxima) 
		{
			GameObject camara = GameObject.FindGameObjectWithTag ("Camara");
			if (camara.GetComponent<ConstruccionPlacement> ().locating == false) 
			{
				nivel += 1;
				imagenLvlUp.SetActive (true);
				textoLvlUp.text = nivel.ToString();
				cantidadExperienciaMaxima = cantidadExperienciaMaxima * 2;
				GameObject almacen = GameObject.FindGameObjectWithTag ("Almacen");
				almacen.GetComponent<ControlAlmacen> ().cantMaximaMateriales += 20;
				if (nivel == 5) 
				{
					GameObject canvas = GameObject.FindGameObjectWithTag ("CanvasPrincipal");
					canvas.GetComponent<ControlObjetivos> ().Objetivo [4] = true;
				}
			}
		}
	}

	public void ActualizarImagenNivel()
	{
		int porcent;
		porcent = (cantidadExperiencia *100)/cantidadExperienciaMaxima;
		if (porcent < 25) 
		{
			imagenNivel.GetComponent<Image>().sprite = spritesNiveles [0];
		}
		if (porcent >= 25 && porcent < 50)  
		{
			imagenNivel.GetComponent<Image>().sprite = spritesNiveles [1];
		}
		if (porcent >= 50 && porcent < 75) 
		{
			imagenNivel.GetComponent<Image>().sprite = spritesNiveles [2];
		}
		if (porcent >= 75 && porcent < 100)  
		{
			imagenNivel.GetComponent<Image>().sprite = spritesNiveles [3];
		}
	}

	public void CerrarImagenLvlUp()
	{
		imagenLvlUp.SetActive (false);
	}
}
