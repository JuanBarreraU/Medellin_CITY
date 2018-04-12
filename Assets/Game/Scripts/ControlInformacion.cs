using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlInformacion : MonoBehaviour
{
    public string nombre;
    public string Descripcion;
    public Sprite imagen;
    public GameObject panelDetalles;
    public GameObject botonRecogerMonedas;

	// Use this for initialization
	void Awake ()
    {
        botonRecogerMonedas.SetActive(false);


	}


	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnMouseDown()
    {
		
        panelDetalles.SetActive(true);
        Image imagenConstruccion = GameObject.FindGameObjectWithTag("ImagenConstruccion").GetComponent<Image>();
        imagenConstruccion.sprite = imagen;
        Text textoN = GameObject.FindGameObjectWithTag("NombreConstruccion").GetComponent<Text>();
        textoN.text = nombre;
        Text textoD = GameObject.FindGameObjectWithTag("TextoDescripcion").GetComponent<Text>();
        textoD.text = Descripcion;
        if (gameObject.name == "Banco")
        {
            botonRecogerMonedas.SetActive(true);
        }
        else
            botonRecogerMonedas.SetActive(false);
            

   
    }
}
