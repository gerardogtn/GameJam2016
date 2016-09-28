using UnityEngine;
using System.Collections;

public class AutoWrite : MonoBehaviour {
    private string str;
    void Start(){
        StartCoroutine( AnimateText("Pretty cool text") );
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator AnimateText(string strComplete){
        int i = 0;
        str = "";
        while( i < strComplete.Length ){
            str += strComplete[i++];
            yield return new WaitForSeconds(0.5F);
        }
    }
}

/*
Especificar string
Especificar tiempo entre letras
Especificar tiempo de espera antes
Especificar tiempo de espear después

*/
