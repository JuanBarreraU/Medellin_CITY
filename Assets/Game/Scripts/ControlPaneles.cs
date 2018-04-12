using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPaneles : MonoBehaviour
{
    public GameObject[] paneles;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AbrirPanel(int panel)
    {
        CerrarPaneles();
        paneles[panel].SetActive(true);
    }

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
		

	public void CerrarPanelInvidialmente(int panel)
	{
		paneles [panel].SetActive (false);
	}

    
}
