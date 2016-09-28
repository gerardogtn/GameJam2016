using UnityEngine;
using System.Collections;

public class LockPlayer : MonoBehaviour {

    void OnTriggerStay(Collider col){

        if(col.gameObject.tag == "Player"){
            col.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            col.transform.parent = null;
        }
    }  
}
