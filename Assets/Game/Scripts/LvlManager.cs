using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LvlManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CargaPartida(string MedellinCity02)
	{
		SceneManager.LoadScene (MedellinCity02);
	}
}
