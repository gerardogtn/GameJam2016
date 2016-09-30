using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager {

	static int current = 0; 
	private static SceneTransitionManager Instance;

	private SceneTransitionManager() {

	}

	public static SceneTransitionManager GetInstance() {
		if (Instance == null) {
			Instance = new SceneTransitionManager ();
		}
		return Instance;
	}

	public void Reload() {
		GoTo (current);
	}

	public void GoToMainMenu() {
		GoTo (0);
	}

	public void GoToTransitionOne() {
		GoTo (1);
	}

	public void GoToLevelOne() {
		GoTo (2);
	}

	public void GoToTransitionTwo() {
		GoTo (3);
	}

	public void GoToLevelTwo() {
		GoTo (4);
	}

	public void GoToTransitionThree() {
		GoTo (5);
	}

	public void GoToLevelThree() {
		GoTo (6);
	}

	public void GoToTransitionFour() {
		GoTo (7);
	}

	public void GoToLevelFour() {
		GoTo (8);
	}

	public void GoToTransitionFive() {
		GoTo (9);
	}

	public void GoToControls() {
		SceneManager.LoadScene (10);
	}

	public void GoToCredits() {
		SceneManager.LoadScene (11);
	}

	private void GoTo(int buildIndex) {
		current = buildIndex;
		SceneManager.LoadScene (buildIndex);
	}
}
