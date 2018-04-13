using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LvlManager : MonoBehaviour {


	//Si se llama esta funcion se cambia del menu a la scena del juego.
	public void CargaPartida(string MedellinCity02)
	{
		SceneManager.LoadScene (MedellinCity02);
	}
}
