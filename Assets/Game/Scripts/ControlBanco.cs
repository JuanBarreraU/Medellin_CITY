using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBanco : MonoBehaviour 
{
	public Text textOro;
	private int oroAcomulado;
	private int oro;
    public Text textTotalOro;
    public int totalOro;
	public GameObject signo;
	public float velRotacion;
	public int gemas;
	public Text textoGemas;
	public GameObject canvas;


	//Se invoca la funcion AumentarOro para que se ejecute cada 1 segundo.
	// se inicia la cantidad de oro en 100.
	void Start () 
	{
		Invoke ("AumentarOro", 1f);
		totalOro = 100;

		
	}
	
	// Se actualizan los textos de oro y  gemas y se pone a rotar el signo que hay sobre el banco.
	void Update () 
	{
		
		textOro.text = "Oro: " + oroAcomulado;
		signo.transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
		textTotalOro.text = ""+totalOro;
		textoGemas.text = "" + gemas;
		
	}

	//Esta funcion se llama cada 120 segundos y aumenta el oro segun la cantidad de personas en la ciudad.
	public void AumentarOro()
	{
		oroAcomulado += (canvas.GetComponent<ControlPoblacion> ().cantidadPersonas / 8);
		Invoke ("AumentarOro", 120);
		
		oro = oroAcomulado;


    }


	//Si se llama esta funcion aumenta el oro acumulado que puede ser recogido por el jugador.
    public void ReclamarOro()
    {
        totalOro += oro;
        oroAcomulado = 0;

    }

	//Si se llama esta funcion se reduce el oro respectivo al pago de alguna construccion.
	public void Pagar(int cantidad)
	{
		if (cantidad <= totalOro)
		{
			totalOro -= cantidad;
		}
	}


	//Si se llama esta funcion se reducen las gemas respectivas al pago de la construccion.
	public void PagarConGemas(int cantidad)
	{
		if (cantidad <= gemas) 
		{
			gemas -= cantidad;
		}
	}



		


}
