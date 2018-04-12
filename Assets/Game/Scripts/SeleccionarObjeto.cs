using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour
{

	Camera camera;

	void Start ()
	{

	}

	void Update ()

	{
		if (Input.GetMouseButtonDown (0))
		{


			RaycastHit hitInfo = new RaycastHit ();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log (hitInfo.transform.gameObject.name);

			}
		}
	}
}
