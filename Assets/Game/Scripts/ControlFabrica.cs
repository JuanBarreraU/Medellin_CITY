using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ControlFabrica : MonoBehaviour 
{
	public int[] cantidadesPosibles;
	public Image[] indicadoresCompras;
	public Text[] textosIndicadoresCompras;
	public Text[] textosCantidadPosible;
	public Text[] textosCostoMaterial;
	public Text[] cantidadesProducidas;
	public Text[] textosTiemposProduccion;
	public int[] costoMateriales;
	public int[] tiemposProduccion;
	public int[] tiemposEstablecidos;



	// Se llama la funcion iniciar Textos para darle contenido a los textos al iniciar.
	void Start () 
	{
		IniciarTextos ();

		
	}
	
	// se Actualizan los textos correspondientes a las cantidades que se pueden fabricar de cada material.
	void Update () 
	{
		for (int i = 0; i < textosCantidadPosible.Length; i++) 
		{
			textosCantidadPosible[i].text = "x" + cantidadesPosibles[i];
			
		}


		
	}

	//Si  se da click sobre la fabrica se abre el panel que le permite al jugador comprar materiales para la construccion.
	public void OnMouseDown()
	{
		GameObject canvas = GameObject.FindGameObjectWithTag ("CanvasPrincipal");
		canvas.GetComponent<ControlPaneles> ().AbrirPanel (8);
	}

	//al llamar esta funcion segun sea el tipo de material, si se tiene el oro necesario, se ejecuta la compra del materarial, y se inicia la fabricacion que dura un tiempo.
	public void ComprarMaterial(int tipo)
	{
		GameObject banco = GameObject.FindGameObjectWithTag ("Banco");
		if (banco.GetComponent<ControlBanco> ().totalOro >= costoMateriales [tipo] && indicadoresCompras[tipo].color == Color.white) 
		{
			banco.GetComponent<ControlBanco> ().totalOro -= costoMateriales [tipo];
			indicadoresCompras [tipo].color = Color.red;
			cantidadesProducidas [tipo].text = textosCantidadPosible [tipo].text;
			textosIndicadoresCompras [tipo].text = "FABRICANDO";
			ActualizarTiempos (tipo);
			switch (tipo) 
			{
			case 0:
				ActualizarCronometroMadera ();
				break;
			case 1:
				ActualizarCronometroHierro ();
				break;
			case 2:
				ActualizarCronometroPlastico ();
				break;

			default:
				break;


			}

		}
	}

	//Al llamar esta funcion se actualizan los tiempos de fabricacion de cada material de construccion.
	public void ActualizarTiempos(int pos)
	{
		tiemposProduccion [pos] = tiemposEstablecidos [pos];
	}

	//Al llamar esta funcion se actualiza el tiempo de fabricacion de la madera constantemente y sus  respectivos textos constantemente.
	public void ActualizarCronometroMadera()
	{
		
		if (tiemposProduccion [0] > 0) 
		{
			tiemposProduccion [0]--;
			TimeSpan tiempo = new TimeSpan (0, 0, tiemposProduccion [0]);
			textosTiemposProduccion [0].text = tiempo.ToString ();
			Invoke ("ActualizarCronometroMadera", 1);
		} 
		else
		{
			indicadoresCompras [0].color = Color.green;
			tiemposProduccion [0] = 0;
			textosIndicadoresCompras [0].text = "ALMACENAR";
		}
	}

	//Al llamar esta funcion se actualiza el tiempo de fabricacion del hierro constantemente y sus  respectivos textos constantemente.
	public void ActualizarCronometroHierro()
	{
		
		if (tiemposProduccion [1] > 0)
		{
			tiemposProduccion [1]--;
			TimeSpan tiempo = new TimeSpan (0, 0, tiemposProduccion [1]);
			textosTiemposProduccion [1].text = tiempo.ToString();
			Invoke ("ActualizarCronometroHierro", 1);
		}
		else
		{
			indicadoresCompras [1].color = Color.green;
			tiemposProduccion [1] = 0;
			textosIndicadoresCompras [1].text = "ALMACENAR";
		}
	}

	//Al llamar esta funcion se actualiza el tiempo de fabricacion del plastico constantemente y sus  respectivos textos constantemente.
	public void ActualizarCronometroPlastico()
	{
		
		if (tiemposProduccion [2] > 0)
		{
			tiemposProduccion [2]--;
			TimeSpan tiempo = new TimeSpan (0, 0, tiemposProduccion [2]);
			textosTiemposProduccion [2].text = tiempo.ToString();
			Invoke ("ActualizarCronometroPlastico", 1);
		}
		else
		{
			indicadoresCompras [2].color = Color.green;
			tiemposProduccion [2] = 0;
			textosIndicadoresCompras [2].text = "ALMACENAR";
		}
	}

	//Al llamar esta funcion se procede a almacenar el material comprado, en el almacen, siempre y cuando no exceda la capacidad del almacen.
	public void Almacenar(int material)
	{
		
		if (indicadoresCompras [material].color == Color.green)
		{
				
			GameObject almacen = GameObject.FindGameObjectWithTag ("Almacen");
			if (almacen.GetComponent<ControlAlmacen> ().cantMaximaMateriales  >= (almacen.GetComponent<ControlAlmacen> ().cantTotalMateriales + cantidadesPosibles [material]))
			{
				almacen.GetComponent<ControlAlmacen> ().cantMateriales [material] += cantidadesPosibles [material];
				almacen.GetComponent<ControlAlmacen> ().ActualizarCantidadMateriales ();
				indicadoresCompras [material].color = Color.white;
				textosIndicadoresCompras [material].text = "SIN COMPRAR";

			}

		}
			
	}

	//Al llamar esta funcion se le da contenido a los textos de fabricacion.
	public void IniciarTextos()
	{
		for (int i = 0; i < cantidadesProducidas.Length; i++) 
		{
			cantidadesProducidas [i].text = "x0";

		}
		for (int i = 0; i < textosCostoMaterial.Length; i++) 
		{
			textosCostoMaterial [i].text = costoMateriales [i].ToString ();

		}
		for (int i = 0; i < textosIndicadoresCompras.Length; i++) 
		{
			textosIndicadoresCompras [i].text = "SIN COMPRAR";
			
		}
	}
		
		
}
