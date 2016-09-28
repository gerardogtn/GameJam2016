using UnityEngine;
using System.Collections;

public class RedSwitch : LiteSwitch {

	void Use() {
		Toggle();
	}

	public override void TurnOn() {
		base.TurnOn ();
		LevelManager.getInstance ().addColor (Colors.Red);
	}

	public override void TurnOff() {
		base.TurnOff (); 
		LevelManager.getInstance ().removeColor (Colors.Red);
	}
}
