using UnityEngine;
using System.Collections;

public class NextLevelScript : MonoBehaviour {

    [SerializeField] int nextLevel; // Enable on inspector
    AutoWrite terminal;
    void Start()
    {
        terminal = AutoWrite.instance;
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {            
            if (this.nextLevel == 2) {
                terminal.AddAction(TransitionTwoCoroutine (), 0.5f);
            } else if (this.nextLevel == 3) {
                terminal.AddAction(TransitionThreeCoroutine (), 0.5f);
            } else if (this.nextLevel == 4) {
                terminal.AddAction(TransitionFourCoroutine (), 0.5f);
            } else if (this.nextLevel == 5) {
                terminal.AddAction(TransitionFiveCoroutine (), 0.5f);
            }
        }
    }

    IEnumerator LevelOneCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToLevelOne ();
        yield return null;
    }

    IEnumerator LevelTwoCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToLevelTwo ();
        yield return null;
    }

    IEnumerator LevelThreeCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToLevelThree ();
        yield return null;
    }

    IEnumerator LevelFourCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToLevelFour ();
        yield return null;
    }

    IEnumerator TransitionTwoCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToTransitionTwo ();
        yield return null;
    }

    IEnumerator TransitionThreeCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToTransitionThree ();
        yield return null;
    }

    IEnumerator TransitionFourCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToTransitionFour();
        yield return null;
    }

    IEnumerator TransitionFiveCoroutine()
    {
        SceneTransitionManager.GetInstance ().GoToTransitionFive ();
        yield return null;
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
