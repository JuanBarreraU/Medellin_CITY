using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {

	//Si lo agregas a un objeto este rotará...

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (new Vector3 (0, 0.3f, 0));
	}
}
