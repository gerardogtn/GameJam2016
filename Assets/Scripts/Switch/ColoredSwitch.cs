using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// Use a colored switch to handle color changes in a switch. 
// Add script to a GameObject in Unity. Set the color of the switch inside the 
// script component in the gameobject. 
public class ColoredSwitch : LiteSwitch {

	public Colors color;

	void Use() {
		Toggle();
	}

	public override void Toggle ()
	{
		bool isOn = ColoredSwitchesManager.getInstance ().IsOn (color);
		if (!isOn) {
			TurnOn ();
		} else {
			TurnOff ();
		}
	}

	public override void TurnOn() {
		base.TurnOn ();
		ColoredSwitchesManager.getInstance ().SetOn (color);
		LevelManager.getInstance ().addColor (color);
		setActive ();
	}

	public override void TurnOff() {
		base.TurnOff (); 
		ColoredSwitchesManager.getInstance ().SetOff (color);
		LevelManager.getInstance ().removeColor (color);
		if (resetType != ResetType.Never && resetType != ResetType.Timed)
			setInactive ();
	}
}
