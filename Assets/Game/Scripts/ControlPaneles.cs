using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPaneles : MonoBehaviour
{
    public GameObject[] paneles;

	//Si se llama esta funcion se abre el panel correspondiente a la posicion dada como argumento.
    public void AbrirPanel(int panel)
    {
        CerrarPaneles();
        paneles[panel].SetActive(true);
    }

	//Si se llama esta funcion se cierran los demas paneles y el boton de reclamar.
    public void CerrarPaneles()
    {
        for (int i = 0; i < paneles.Length; i++)
        {
            paneles[i].SetActive(false);

        }

		GameObject reclamar = GameObject.FindGameObjectWithTag ("BotonReclamar");
		if (reclamar) 
		{
			reclamar.SetActive (false);
		}
    }
		
	//Al llamar esta funcion se cierra solo el panel indicado en el argumento.
	public void CerrarPanelInvidialmente(int panel)
	{
		paneles [panel].SetActive (false);
	}

    
}
