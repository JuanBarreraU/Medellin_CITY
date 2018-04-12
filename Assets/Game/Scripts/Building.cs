using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private PlacableConstruccion placableConstruccion;
    private Transform currentBuilding;
    public Camera camara;
    public LayerMask BuildingMask;
    public LayerMask BlockedMask;


    private bool locating;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int x = -10;
        int z = -10;

        if (locating)
        {

            if (Physics.Raycast(ray, out hit, 1000, BuildingMask))
            {
                x = (int)(hit.point.x + 0.5f);
                z = (int)(hit.point.z + 0.5f);
                if (Input.GetMouseButtonDown(0))
                {
                    if (IsLegalPosition())
                    {
                        locating = false;
                    }

                }
            }


            if (x > 0 && z > 0)
            {
                currentBuilding.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }
        else
        {
            if (Physics.Raycast(ray, out hit, 1000, BlockedMask))
            {

                if (Input.GetMouseButtonDown(0))

                {
                    Debug.Log(hit.collider.name);
                }
            }
        }


    }

    bool IsLegalPosition()
    {
        if (placableConstruccion.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }

    public void SetItem(GameObject b)
    {
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        locating = true;
        placableConstruccion = currentBuilding.GetComponent<PlacableConstruccion>();
    }
}




