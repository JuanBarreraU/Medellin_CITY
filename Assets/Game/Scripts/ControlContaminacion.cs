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



	// Use this for initialization
	void Start () 
	{
		cantidadContaminacion = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		CambiarEstado ();
		ActualizarIndicadorContaminacion ();
		ActualizarPorcentaje ();
	}

	public void AumentarContaminacion(float cantidad)
	{
		cantidadContaminacion += cantidad;
	}

	public void DisminuirContaminacion(float cantidad)
	{
		cantidadContaminacion -= cantidad;
	}

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

	public void ActualizarPorcentaje()
	{
		porcentajeContaminacion.text = (100 - cantidadContaminacion) + "%";
	}

	public void ActualizarIndicadorContaminacion()
	{
		barraContaminacion.value = cantidadContaminacion;
	}
}
