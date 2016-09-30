using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FullScreenSender : MonoBehaviour {

    public int nextLevel; 
    public bool moveToLevel = false;

    AutoWrite terminal;
    [System.Serializable]   
    public struct MessageParams{        
        public string keyboardMessage;
        public string controllerMessage;
        public float totalDuration;
        public float beforeTime;
        public float afterTime;
    };

    public List<MessageParams> messages = new List<MessageParams>();


    void Start()
    {
        terminal = AutoWrite.instance;
        sendMessages();
        if (moveToLevel)
        {            
            Debug.Log("HOLA");
            sendGoToNextLevel();
        }
//        else
//        {
//            sendGoToNextTransition();
//        }
    }
        
    void sendMessages()
    {        
        for (int i = 0; i < messages.Count; i++)
        {
                if (Input.GetJoystickNames().Length > 0)
                    terminal.WriteToTerminal(messages[i].controllerMessage != "" ? messages[i].controllerMessage : messages[i].keyboardMessage, true, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
                else
                    terminal.WriteToTerminal(messages[i].keyboardMessage, true, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);            
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


	void sendGoToNextLevel() {
		if (this.nextLevel == 1) {
			terminal.AddAction(LevelOneCoroutine (), 0.5f);
		} else if (this.nextLevel == 2) {
			terminal.AddAction(LevelTwoCoroutine (), 0.5f);
		} else if (this.nextLevel == 3) {
			terminal.AddAction(LevelThreeCoroutine (), 0.5f);
		} else if (this.nextLevel == 4) {
			terminal.AddAction(LevelFourCoroutine (), 0.5f);
		}
	}

    void sendGoToNextTransition() {
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
