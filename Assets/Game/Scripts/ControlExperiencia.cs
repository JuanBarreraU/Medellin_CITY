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

	// la cantidad de experiencia inicia en 0. y la cantidad de experiencia maxima antes de avanzar al siguiente nivel, inicia en 100.
	//El nivel inicial es el 1.
	void Start () 
	{
		cantidadExperiencia = 0;
		cantidadExperienciaMaxima = 100;
		nivel = 1;
	}
	
	// Se llama a la funcion ActualizarTextoNivel para mantener actualizado el nivel en pantalla.
	//Se llama a la funcion ActualizarTextoExperiencia para mantener actualizada la cantidad de experiencia en pantalla.
	//Se llama la funcion AumentarNivel que indicará en que momento debe subir de nivel.
	//Se llama la funcion actualizarImagenNivel para actualizar la imagen que indica cuanta cantidad de experiencia lleva mediante imagenes.
	void Update () 
	{
		ActualizarTextoNivel ();
		ActualizarTextoEsperiencia ();
		AumentarNivel ();
		ActualizarImagenNivel ();
		
	}

	//Al llamar esta funcion se actualiza el texto correspondiente al nivel en pantalla, segun el nivel de juego del jugador.
	public void ActualizarTextoNivel()
	{
		textoNivel.text = nivel.ToString ();
	}

	//Al llamar esta funcion se actualiza el texto correspondiente a la cantidad de experiencia que puede ser visti en pantalla por el jugador.
	public void ActualizarTextoEsperiencia()
	{
		textoCantidadExperiencia.text = cantidadExperiencia + "/" + cantidadExperienciaMaxima;
	}


	//Al llamar esta funcion se aumenta la experiencia segun la cantidad dada como argumento.
	public void AumentarExperiencia(int cantidad)
	{
		cantidadExperiencia += cantidad;
	}

	//Al llamar esta funcion si la cantidad de experiendia es mayor o igual a la cantidad de experiencia maxima, se aumenta en un nivel.
	//Se activa la imagen que indica que has subido de nivel.
	//Cada que subes de nivel la cantidad maxima de materiales en el almacen aumenta en 20.
	//Si llegas al nivel 5 aumentas alcanzas un objetivo.
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

	//al llamar esta funcion se actualiza la imagen que muestra el porcentaje de experiencia acumulada antes de aumentar de nivel.
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

	//Al llamar esta funcion se cierra la imagen que indica que subiste de nivel.
	public void CerrarImagenLvlUp()
	{
		imagenLvlUp.SetActive (false);
	}
}
