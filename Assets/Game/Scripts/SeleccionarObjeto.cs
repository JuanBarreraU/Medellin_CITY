using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour
{

	Camera camera;
	public GameObject canvas;



	void Update ()

	{
		GameObject[] cubos;
		cubos = GameObject.FindGameObjectsWithTag ("cubo");
		
		RaycastHit hitInfo = new RaycastHit ();
		bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
		if (hit) 
		{
			Debug.Log (hitInfo.transform.gameObject.name);
			if (canvas.GetComponent<ControlRemover> ().remover == true) 
			{
				for (int i = 0; i < cubos.Length; i++) 
				{
					cubos [i].SetActive (false);
				}



			
				if ( hitInfo.transform.gameObject.tag == ("CasaLvl1") || hitInfo.transform.gameObject.tag == ("CasaLvl2") || hitInfo.transform.gameObject.tag == ("Calle") )
				{
					hitInfo.transform.gameObject.GetComponent<ControlConstruccion> ().cubo.SetActive (true);
					if (Input.GetMouseButtonDown (0)) 
					{
						Destroy (hitInfo.transform.gameObject);
					}
				}
				if (hitInfo.transform.gameObject.tag == ("Banco") || hitInfo.transform.gameObject.tag == ("TorreControlAire") || hitInfo.transform.gameObject.tag == ("Fabrica") || hitInfo.transform.gameObject.tag == ("Almacen") || hitInfo.transform.gameObject.tag == ("Coltejer"))
				{
					hitInfo.transform.gameObject.GetComponent<ControlConstruccion> ().cubo.SetActive (true);
					if (Input.GetMouseButtonDown (0)) 
					{
						hitInfo.transform.gameObject.SetActive (false);
					}
				}
			}

		}
	}

}
