using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            AutoWrite.instance.coroutineQueue.StopLoop();
            StopAllCoroutines();
            SceneTransitionManager.GetInstance().resetLevel();
        }
    }
}
