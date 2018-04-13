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
	public GameObject canvas;

	// El boton para recoger monedas inicia desactivado.
	void Awake ()
    {
        botonRecogerMonedas.SetActive(false);
	}
		
	//Si se da clic sobre alguna construccion con este script, se activara el panel de detalles y se actualizaran los textos correspondientes a la construccion.
	//Si el la construccion que tiene este script es el banco, se activara el boton que permite recoger monedas. de lo contrario seguira inactivo.
    public void OnMouseDown()
    {
        GameObject camara = GameObject.FindGameObjectWithTag("Camara");
        if (camara.GetComponent<ConstruccionPlacement>().locating == false)
        {
            if (canvas.GetComponent<ControlRemover>().remover == false)
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
		

   
    }
}
