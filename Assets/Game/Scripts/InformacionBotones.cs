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

	//Si el cursor esta sobre el objeto que tenga este script, se activara la infirmacion para que pueda verse en pantalla.
    public void OnPointerEnter(PointerEventData eventData)
    {
        informacion.SetActive(true);
		textoNombre.text = nombre;
		if (costo) 
		{
			costo.SetActive (true);
		}
    }

	//Si el cursor deja de estar sobre el objeto con este script, se desactiva la informacion.
    public void OnPointerExit(PointerEventData eventData)
    {

        informacion.SetActive(false);
		if (costo) 
		{
			costo.SetActive (false);
		}
    }

	//Si se da click sobre el objeto con este script, se desactiva la informacion.
    public void OnPointerClick(PointerEventData eventData)
    {

        informacion.SetActive(false);
		if (costo) 
		{
			costo.SetActive (false);
		}
    }

}