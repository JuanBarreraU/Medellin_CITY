using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
	public Camera  camaraJuego;
	public int max;
	public int min;


	void Update () 
	{
		Zoom ();
		ArrastrarCamara ();

	}

	public void Zoom ()
	{
		float d = Input.GetAxis ("Mouse ScrollWheel");

		if (d > 0f) {
			if (camaraJuego.fieldOfView >= min) {
				camaraJuego.fieldOfView = camaraJuego.fieldOfView - 10;
			}
		} else if (d < 0f) {
			if (camaraJuego.fieldOfView <= max) {
				camaraJuego.fieldOfView = camaraJuego.fieldOfView + 10;
			}
		}
	}

	public void Mover()
	{
		float dir_x = Input.GetAxis ("Mouse X");
		float dir_z = Input.GetAxis ("Mouse Y");
		transform.Translate (-dir_x * 1, 0, -dir_z * 1);
	}

	public void ArrastrarCamara ()
	{

        if (camaraJuego.fieldOfView == 40)
        {
            transform.position = new Vector3(45.5f, 85.37f, -10f);
        }
        if (Input.GetMouseButton(1))
		{
			

			if (camaraJuego.fieldOfView == 30)
			{
				transform.position = new Vector3 ((Mathf.Clamp (transform.position.x, 20f, 72f)), transform.position.y, Mathf.Clamp (transform.position.z, -22f, 20f));
				Mover ();
			}

			if (camaraJuego.fieldOfView == 20)
			{
				transform.position = new Vector3 ((Mathf.Clamp (transform.position.x, 15f, 84f)), transform.position.y, Mathf.Clamp (transform.position.z, -40f, 23f));
				Mover ();
			}

			if (camaraJuego.fieldOfView == 10)
			{
				transform.position = new Vector3 ((Mathf.Clamp (transform.position.x, 0f, 90f)), transform.position.y, Mathf.Clamp (transform.position.z, -43f, 30f));
				Mover ();
			}


		}

	}

}


