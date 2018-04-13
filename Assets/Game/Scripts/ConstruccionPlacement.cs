using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionPlacement : MonoBehaviour 
{
    private Transform currentBuilding;
    public Camera camara;
    public LayerMask BuildingMask;
	public bool puedeConstruir;
    public bool locating;

    private void Start()
    {
        locating = false;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int x = -10;
        int z = -10;

        if (locating)
        {
            //si el raycast toca un objeto con layer indicado para construir, el objeto que queremos construir conserva su color.
            //si se cumple lo anterior y posicionamos el objeto a construir sobre otro objeto que tenga el tag torre, nuestro objeto a construir conserva su color.
            //si se cumple lo anterior y damos click sobre el objeto con el tag Torre, nuestro objeto a construir se posicionara en ese lugar.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, BuildingMask))
            {
				if (hit.transform.CompareTag("Building") && puedeConstruir == true )
                {
                    x = (int)(hit.point.x + 0.5f);
                    z = (int)(hit.point.z + 0.5f);
                    /*Material[] materialesConstruccion = currentBuilding.GetComponentInChildren<Renderer>().materials;
                    for (int i = 0; i < materialesConstruccion.Length; i++)
                        materialesConstruccion[i].color = Color.white;*/
                    if (Input.GetMouseButtonDown(0))
                    {
                        currentBuilding.gameObject.layer = 8;
						currentBuilding.gameObject.GetComponent<ControlConstruccion> ().ubicado = true;
                        locating = false;
                       
                        return;
                    }
                }

                //Si las condiciones anteriores no se cumplen, el objeto se verá de color rojo y no se puede instanciar en ese lugar.
                else
                {
                    x = (int)(hit.point.x + 0.5f);
                    z = (int)(hit.point.z + 0.5f);
                    /*Material[] materialesConstruccion = currentBuilding.GetComponentInChildren<Renderer>().materials;
                    for(int i = 0;i < materialesConstruccion.Length;i++)
                        materialesConstruccion[i].color = Color.red;*/
                }
            }
            if (x > 0 && z > 0)
            {
                currentBuilding.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }



    }


	//Si se llama esta funcion el objeto a construir se instancia en la posicion del cursor del mouse.
    public void SetItem(GameObject b)
    {
        if (!locating)
        {
            currentBuilding = ((GameObject)Instantiate(b)).transform;
            currentBuilding.gameObject.layer = 0;
            locating = true;
        }

    }

	//Si se llama esta funcion el objeto a construir toma la posicion del cursor del mouse.
	public void Construir(GameObject b)
	{
		if (!locating)
		{
			currentBuilding = ((b)).transform;
			currentBuilding.gameObject.layer = 0;
			locating = true;
		}

	}



}