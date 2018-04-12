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

	// Use this for initialization
	void Start ()
    {
        cantCasasProximaMejora[0] = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        cantCasasLvl1 = GameObject.FindGameObjectsWithTag("CasaLvl1");
        cantCasasLvl2 = GameObject.FindGameObjectsWithTag("CasaLvl2");
        ActivarMejorasLvl1();
    }

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
