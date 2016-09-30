using UnityEngine;
using System.Collections;

public class TransitionBehavior : MonoBehaviour {

	void Reload() {
		SceneTransitionManager.GetInstance ().Reload ();
	}

	public void GoToMenu() {
		SceneTransitionManager.GetInstance ().GoToMainMenu ();
	}

	public void GoToTransitionOne() {
		SceneTransitionManager.GetInstance ().GoToTransitionOne ();
	}

	public void GoToCredits() {
		SceneTransitionManager.GetInstance ().GoToCredits ();
	}

	public void GoToControls() {
		SceneTransitionManager.GetInstance ().GoToControls ();
	}

}
