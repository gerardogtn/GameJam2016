using UnityEngine;
using System.Collections;

public abstract class ColorReceiver : MonoBehaviour {

	// Use this for initialization
	public virtual void Start () {
		LevelManager instance = LevelManager.getInstance ();
		instance.LightChanged += new LevelManager.PerformLightChange (OnColorReceived);
	}
		
	public virtual void OnDestroy () {
		LevelManager instance = LevelManager.getInstance ();
		instance.LightChanged -= new LevelManager.PerformLightChange (OnColorReceived);
	}

	public abstract void OnColorReceived (Colors color);

}
