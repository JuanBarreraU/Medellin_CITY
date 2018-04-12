using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InformacionBotones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject informacion;
	public string nombre;
	public Text textoNombre;
	public GameObject costo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        informacion.SetActive(true);
		textoNombre.text = nombre;
		if (costo) 
		{
			costo.SetActive (true);
		}
    }
    public void OnPointerExit(PointerEventData eventData)
    {

        informacion.SetActive(false);
		if (costo) 
		{
			costo.SetActive (false);
		}
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        informacion.SetActive(false);
		if (costo) 
		{
			costo.SetActive (false);
		}
    }

}