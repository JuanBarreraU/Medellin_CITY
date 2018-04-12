using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {

	public void BotonJugar ()
    {
        SceneManager.LoadScene("MedellinCity");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }
}
