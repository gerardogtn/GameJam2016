using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestTerminal : MonoBehaviour {

    [SerializeField]
    List<string> messages = new List<string>();
    [SerializeField]
    AutoWrite terminal;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            messages.ForEach(n => terminal.WriteToTerminal(n));
        }
	}
}
