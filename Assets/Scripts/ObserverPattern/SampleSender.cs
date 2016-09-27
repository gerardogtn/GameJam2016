using UnityEngine;
using System.Collections;

public class SampleSender : MonoBehaviour {

	private static int COUNTER = 0; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		COUNTER++; 
		if (COUNTER == 20) {
			COUNTER = 0; 
			Debug.Log ("Sending message!");
			LevelManager.getInstance ().addColor (Colors.Red); 
		}
	}
}
