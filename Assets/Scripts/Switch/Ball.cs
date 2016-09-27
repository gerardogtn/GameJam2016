using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public bool isOpen;
    [SerializeField]
    Material openMaterial;
    [SerializeField]
    Material closeMaterial;
    [SerializeField]
    int knocksToOpen;

    int currentKnocks;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open()
    {
        currentKnocks++;
        if (!isOpen && currentKnocks == knocksToOpen)
            setState(true);
        
    }

    public void Close()
    {
        currentKnocks--;
        if (isOpen&& currentKnocks < knocksToOpen)
            setState(false);
    }

    public void Toggle()
    {
        if (isOpen)
            Close();
        else
            Open();
    }

    void setState(bool open)
    {
        isOpen = open;
        if (open)
        {
            gameObject.GetComponent<MeshRenderer>().material = openMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = closeMaterial;
        }
    }
}
