using UnityEngine;
using System.Collections;

public class NextLevelScript : MonoBehaviour {

    [SerializeField] int nextLevel; // Enable on inspector 
   
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("HOLA");
            GoToNextLevel();
        }
    }

    void GoToNextLevel() {
        if (nextLevel == 2)
        {
            SceneTransitionManager.GetInstance().GoToTransitionTwo();
        }
        else if (nextLevel == 3)
        {
            SceneTransitionManager.GetInstance().GoToTransitionThree();
        }
        else if (nextLevel == 4)
        {
            SceneTransitionManager.GetInstance().GoToTransitionFour();
        }
        else if (nextLevel == 5)
        {
            SceneTransitionManager.GetInstance().GoToTransitionFive();
        }
        
    }

}
