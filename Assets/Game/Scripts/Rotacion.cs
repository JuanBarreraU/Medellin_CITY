using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {


	
	// el objeto con este script rota en el eje y.
	void Update () {
	
		transform.Rotate (new Vector3 (0, 0.3f, 0));
	}
}
