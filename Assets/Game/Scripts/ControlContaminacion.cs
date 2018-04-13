using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlContaminacion : MonoBehaviour 
{
	public float cantidadContaminacion;
	public Slider barraContaminacion;
	public Sprite[] estados;
	public Image imagenEstado;
	public Text porcentajeContaminacion;



	// La cantidad de contaminacion inicia en 0.
	void Start () 
	{
		cantidadContaminacion = 0;

	}
	
	// Se llama la funcion cambiar estado para actualizar el estado constantemente.
	//Se actualiza el indicador de contaminacion constantemente.
	//Se actualiza el porcentaje de prosperidad de la ciudad.
	void Update () 
	{
		CambiarEstado ();
		ActualizarIndicadorContaminacion ();
		ActualizarPorcentaje ();
	}

	//Al llamar esta funcion se aumenta la contaminacion segun la cantidad entregada como argumento.
	public void AumentarContaminacion(float cantidad)
	{
		cantidadContaminacion += cantidad;
	}

	//Al llamar esta funcion se disminuye la contaminacion segun la cantidad entregada como argumento.
	public void DisminuirContaminacion(float cantidad)
	{
		cantidadContaminacion -= cantidad;
	}

	//Al ser llamada esta funcion, la imagen del estado de prosperidad de la ciudad cambia segun la cantidad de contaminacion existente.
	public void CambiarEstado()
	{
		if (cantidadContaminacion < 20f) 
		{
			imagenEstado.sprite = estados [0];
		}
		if (cantidadContaminacion >= 20f && cantidadContaminacion < 40) 
		{
			imagenEstado.sprite = estados [1];
		}
		if (cantidadContaminacion >= 40f && cantidadContaminacion < 60) 
		{
			imagenEstado.sprite = estados [2];
		}
		if (cantidadContaminacion >= 60f && cantidadContaminacion < 80) 
		{
			imagenEstado.sprite = estados [3];
		}
		if (cantidadContaminacion > 80f) 
		{
			imagenEstado.sprite = estados [4];
		}
	}

	//Al ser llamada esta funcion se actualiza el texto correspondiente al porcentaje de prosperidad de la ciudad con respecto a la contaminacion.
	public void ActualizarPorcentaje()
	{
		porcentajeContaminacion.text = (100 - cantidadContaminacion) + "%";
	}

	//Al ser llamada esta funcion se actualiza el indicador de contaminacion segun la cantidad de contaminacion.
	public void ActualizarIndicadorContaminacion()
	{
		barraContaminacion.value = cantidadContaminacion;
	}
}
