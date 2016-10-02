using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColoredSwitchesManager {

	private static ColoredSwitchesManager instance; 
	private static Dictionary<Colors, bool> colorStatus;

	private ColoredSwitchesManager() {
		colorStatus = new Dictionary<Colors, bool> ();
		Reset ();
	}

	public void Reset() {
		colorStatus [Colors.Red] = false;
		colorStatus [Colors.Green] = false;
		colorStatus [Colors.Blue] = false;
		colorStatus [Colors.Cyan] = false;
		colorStatus [Colors.Magenta] = false;
		colorStatus [Colors.Yellow] = false;
		colorStatus [Colors.Black] = false;
		colorStatus [Colors.White] = false;
	}

	public static ColoredSwitchesManager getInstance() {
		if (instance == null) {
			instance = new ColoredSwitchesManager ();
		}
		return instance;
	}

	public bool IsOn(Colors color) {
		return colorStatus [color];
	}

	public void SetOn(Colors color) {
		colorStatus [color] = true;
	}

	public void SetOff(Colors color) {
		colorStatus [color] = false;
	}
}

