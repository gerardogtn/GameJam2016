using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchTrigger : MonoBehaviour {

	HashSet<Collider> inColliders = new HashSet<Collider>();
	void Update()
	{
		if (IsSwitchedTriggered ()) {
			Trigger ();
		}
	}

	bool IsSwitchedTriggered() {
		return Input.GetButtonDown ("ToggleSwitch"); 
	}

	void Trigger() {
		foreach (var collider in inColliders) {
			collider.SendMessage ("Use", SendMessageOptions.DontRequireReceiver);
		} 
	}

	void OnTriggerEnter(Collider col)
	{
		inColliders.Add(col);
	}

	void OnTriggerExit(Collider col)
	{
		inColliders.Remove(col);
	}
}
