using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlTutorial : MonoBehaviour 
{
	public Text textoTutorial;
	public GameObject canvasJuego;
	public GameObject flecha;
	public Image Bob;
	public Sprite[] imagenesDialogo;
	public int cantClicks;
	public GameObject botonCerrar;
	public GameObject canvas;

	// La flecha del tutorial inicia desactivada.
	void Start () 
	{
		flecha.SetActive (false);
	}
	
	// Se llama la funcion ActualizarDialogo para actualizar el dialogo en pantalla en todo momento mientras el tutorial.
	void Update () 
	{
		ActualizarDialogo ();
	}

	//Al llamar esta funcion aumenta la cantidad de clicks en 1.
	public void DarClick()
	{
		cantClicks++;
	}

	//Si se llama esta funcion se actualiza el dialogo del tutorial.
	//cada que aumente la cantidad de clicks el dialogo cambia hasta terminarse el tutorial.
	public void ActualizarDialogo()
	{
		GameObject[] botones = GameObject.FindGameObjectsWithTag ("Boton");
		switch (cantClicks) 
		{
		case 0:
			textoTutorial.text = "Hola señor Alcalde!\nMi nombre es Bob y soy el encargado de dirigir las construcciones de la ciudad.";
			Bob.sprite = imagenesDialogo [0];
			botonCerrar.SetActive (true);
			break;
		case 1:
			textoTutorial.text = "Lo primero que haremos para que nuesta ciudad prospere será construir el banco.\nPara esto selecciona el boton correspondiente al banco y construyelo en el lugar deseado.";
			Bob.sprite = imagenesDialogo [1];
			botonCerrar.SetActive (false);
			canvasJuego.SetActive (true);
			flecha.SetActive (true);

			for (int i = 0; i < botones.Length ; i++) 
			{
				botones [i].GetComponent<Button> ().interactable = false;
				
			}
			break;
		case 2:
			GameObject camara = GameObject.FindGameObjectWithTag ("Camara");
			if (camara.GetComponent<ConstruccionPlacement> ().locating == false) 
			{
				textoTutorial.text = "Ahora da click en los diferentes botones de tu pantalla y descubre como hacer que tu ciudad prospere y te conviertas en el mejor alcalde.";
				Bob.sprite = imagenesDialogo [2];
				botonCerrar.SetActive (true);
			}
			break;
		case 3:
			for (int i = 0; i < botones.Length ; i++) 
			{
				botones [i].GetComponent<Button> ().interactable = true;

			}
			Destroy (canvas, 0.1f);
			break;
		default:
			break;
		}
	}
}
