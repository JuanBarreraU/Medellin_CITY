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

	//Se cambia de cursor.
	public void CambiarCursor()
	{
		Cursor.SetCursor (cursorRemover, hotSpot, modoCursor);
	}

	public void IniciarDemolicion ()
	{
		remover = !remover;
	}

}
