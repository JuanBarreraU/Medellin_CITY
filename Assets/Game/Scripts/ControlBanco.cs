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


	// Use this for initialization
	void Start () 
	{
		Invoke ("AumentarOro", 1f);
		totalOro = 100;

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		textOro.text = "Oro: " + oroAcomulado;
		signo.transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
		textTotalOro.text = ""+totalOro;
		textoGemas.text = "" + gemas;
		
	}

	public void AumentarOro()
	{
		 



		oroAcomulado += (canvas.GetComponent<ControlPoblacion> ().cantidadPersonas / 4);
		Invoke ("AumentarOro", 10);
		
		oro = oroAcomulado;


    }



    public void ReclamarOro()
    {
        totalOro += oro;
        oroAcomulado = 0;

    }

	public void Pagar(int cantidad)
	{
		if (cantidad <= totalOro)
		{
			totalOro -= cantidad;
		}
	}

	public void PagarConGemas(int cantidad)
	{
		if (cantidad <= gemas) 
		{
			gemas -= cantidad;
		}
	}



		


}
