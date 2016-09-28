using UnityEngine;
using System.Collections;


// Use a colored switch to handle color changes in a switch. 
// Add script to a GameObject in Unity. Set the color of the switch inside the 
// script component in the gameobject. 
public class ColoredSwitch : LiteSwitch {

	public Colors color;

	public ColoredSwitch() {
		onMessage = "Open";
		offMessage = "Close";
	}

	void Use() {
		Toggle();
	}

	public override void TurnOn() {
		base.TurnOn ();
		LevelManager.getInstance ().addColor (color);
	}

	public override void TurnOff() {
		base.TurnOff (); 
		LevelManager.getInstance ().removeColor (color);
	}
}
