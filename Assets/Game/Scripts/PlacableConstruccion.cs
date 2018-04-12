using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableConstruccion : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    private bool isSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if(isSelected)
        {
            GUI.Button(new Rect(100, 200, 100, 30), name);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Building")
        {
            colliders.Add(c);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if(c.tag == "Building")
        {
            colliders.Remove(c);
        }
    }

    public void SetSelected(bool s)
    {
        isSelected = s;
    }
}
