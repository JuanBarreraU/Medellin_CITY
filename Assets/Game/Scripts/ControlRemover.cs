using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRemover : MonoBehaviour 
{
	public Texture2D cursorRemover;
	public CursorMode modoCursor = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public bool remover;

	// Use this for initialization
	void Start () 
	{
		remover = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (remover == true) 
		{
			CambiarCursor ();
		} 
		else
		{
			Cursor.SetCursor (null, hotSpot, modoCursor);
		}
	}

	//Al llamar esta funcion, el cursor toma la textura indicada.
	public void CambiarCursor()
	{
		Cursor.SetCursor (cursorRemover, hotSpot, modoCursor);
	}

    //si se llama esta funcion, la variable remover cambia de verdadero a falso y viceversa.
	public void IniciarDemolicion ()
	{
		remover = !remover;
	}

}
