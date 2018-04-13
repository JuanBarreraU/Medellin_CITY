using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMejoras : MonoBehaviour
{
    public GameObject[] cantCasasLvl1;
    public GameObject[] cantCasasLvl2;
    public int[] cantCasasProximaMejora;
    public GameObject[] casasLvl2;
    public GameObject[] casasLvl3;

	// Se indica que la cantidad de casas necesaria para la primera mejora son 5.
	void Start ()
    {
        cantCasasProximaMejora[0] = 5;
	}
	
	// se busca cuantas casas hay en la escena de nivel 1 y de nivel 2.
	// Se llama a la funcion ActivarMejoras para saber cuando una casa debe pedir mejoras.
	void Update ()
    {
        cantCasasLvl1 = GameObject.FindGameObjectsWithTag("CasaLvl1");
        cantCasasLvl2 = GameObject.FindGameObjectsWithTag("CasaLvl2");
        ActivarMejorasLvl1();
    }

	//Al llamar esta funcion, si la cantidad de casas de lvl 1 es mayor o igual a la cantidad de casas necesarias para la primer mejora.
	//se activa la imagen de mejora en una de las casas.
    public void ActivarMejorasLvl1()
    {
        if(cantCasasLvl1.Length >= cantCasasProximaMejora[0])
        {
            GameObject camara = GameObject.FindGameObjectWithTag("Camara");
            if (camara.GetComponent<ConstruccionPlacement>().locating == false)
            {
                int numCasa = Random.Range(0, cantCasasLvl1.Length);
                cantCasasLvl1[numCasa].GetComponent<ControlBotonMejoras>().ActivarMejora();
                cantCasasProximaMejora[0] += 5;
            }
        }
    }

    
}
