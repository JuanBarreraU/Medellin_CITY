using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRemover : MonoBehaviour 
{
	public Texture2D cursorRemover;
	public CursorMode modoCursor = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//Se cambia de cursor.
	public void CambiarCursor()
	{
		Cursor.SetCursor (cursorRemover, hotSpot, modoCursor);
	}
}
