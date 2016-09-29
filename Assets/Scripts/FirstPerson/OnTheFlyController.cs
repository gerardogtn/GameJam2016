using UnityEngine;
using System.Collections;

public class OnTheFlyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (IsRedTriggered ()) {
			Toggle (Colors.Red);
		}
		if (IsGreenTriggered ()) {
			Toggle (Colors.Green);
		}
		if (IsBlueTriggered ()) {
			Toggle (Colors.Blue);
		}
	}

	bool IsRedTriggered() {
		return Input.GetButtonDown ("Red");
	}

	bool IsGreenTriggered() {
		return Input.GetButtonDown ("Green");
	}

	bool IsBlueTriggered() {
		return Input.GetButtonDown ("Blue");
	}

	void Toggle(Colors color) {
		bool isOn = ColoredSwitchesManager.getInstance ().IsOn (color);
		if (!isOn) {
			TurnOn (color);
		} else {
			TurnOff (color);
		}
	}

	void TurnOn(Colors color) {
		ColoredSwitchesManager.getInstance ().SetOn (color);
		LevelManager.getInstance ().addColor (color);
	}

	void TurnOff(Colors color) {
		ColoredSwitchesManager.getInstance ().SetOff (color);
		LevelManager.getInstance ().removeColor (color);
	}
}
	