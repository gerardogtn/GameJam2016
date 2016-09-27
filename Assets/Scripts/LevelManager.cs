using UnityEngine;
using System.Collections;

public class LevelManager {

	// Singleton pattern.
	private static LevelManager instance; 
	private Colors activeColor;

	public static LevelManager getInstance() {
		if (instance == null) {
			instance = new LevelManager ();
		}
		return instance;
	}

	private LevelManager() {
		activeColor = Colors.Black;
	}

	// Delegate (Observable/Observer) pattern 
	public delegate void PerformLightChange(Colors color); 
	public event PerformLightChange LightChanged; 

	private void OnLightChanged(Colors color) {
		if (LightChanged != null) {
			LightChanged (color);
		}
	}

	// Add color 
	public void addColor(Colors color) {
		activeColor = activeColor.Add (color);
		OnLightChanged (activeColor);
	}

	// Remove color
	public void removeColor(Colors color) {
		activeColor = activeColor.Remove (color);
		OnLightChanged (activeColor);
	}
}
