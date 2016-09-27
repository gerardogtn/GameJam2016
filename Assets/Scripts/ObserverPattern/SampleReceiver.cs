using UnityEngine;
using System.Collections;

public class SampleReceiver : MonoBehaviour {

	// The object will subscribe to events when it's created. 
	void Start () {
		LevelManager instance = LevelManager.getInstance ();
		instance.LightChanged += new LevelManager.PerformLightChange (OnNewColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// The object will unsubscribe from events when destroyed. 
	void OnDestroy () {
		LevelManager instance = LevelManager.getInstance ();
		instance.LightChanged -= new LevelManager.PerformLightChange (OnNewColor);
	}

	// When a new event is received, the new color will be printed. 
	void OnNewColor(Colors color) {
		Debug.Log (color.getString ());
	}
}
