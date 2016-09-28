using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AutoWrite : MonoBehaviour {

    [SerializeField]
    Text textArea;   
    [SerializeField]
    float totalDurationDefault = 3f;
    [SerializeField]
    float waitTimeBeforeDefault = 0.0f;
    [SerializeField]
    float waitTimeAfterDefault = 0.0f;

    private CoroutineQueue coroutineQueue;


    void Start(){
        coroutineQueue = new CoroutineQueue(this);
        coroutineQueue.StartLoop();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WriteToTerminal(string text, float? _totalDuration = null ,  float? _waitTimeBefore = null, 
        float? _waitTimeAfter = null)
    {
        float _totalDurationInit = _totalDuration ?? totalDurationDefault;
        float _waitTimeBeforeInit = _waitTimeBefore ?? waitTimeBeforeDefault;
        float _waitTimeAfterInit = _waitTimeAfter ?? waitTimeAfterDefault;

        coroutineQueue.EnqueueWait(_waitTimeBeforeInit);
        coroutineQueue.EnqueueAction(WriteString(text, _totalDurationInit, _waitTimeBeforeInit, _waitTimeAfterInit));
        coroutineQueue.EnqueueWait(_waitTimeAfterInit);
    }

    IEnumerator WriteString(string text, float totalDuration, float _waitTimeBefore, float _waitTimeAfter)
    {
        int characterIndex = 0;
        while (characterIndex < text.Length)
        {
            int openCounter = 0;
            int closeCounter = 0;
            int firstTagStart = 0;
            int firstTagEnd = 0;
            int secondTagStart = 0;
            int secondTagEnd = 0;
            if (text[characterIndex] == '<')
            {
                bool foundTag = true;
                int initialCharacterIndex = characterIndex + 1;
                string richText = "";
                bool done = false;
                while (!done)
                {                    
                    if (text[characterIndex] == '<')
                    {
                        openCounter++;
                        if (openCounter == 1)
                            firstTagStart = characterIndex;   
                        if (openCounter == 2)
                            secondTagStart = characterIndex;   
                    }
                    else if (text[characterIndex] == '>')
                    {                        
                        closeCounter++;   
                        if (closeCounter == 1)
                            firstTagEnd = characterIndex;
                        if (closeCounter == 2)
                            secondTagEnd = characterIndex; 
                    }
                    else if (openCounter >= 1 && closeCounter >= 1)
                    {
                        if(openCounter < 2)
                            richText += text[characterIndex];
                    }
                    characterIndex++;                        
                    if (closeCounter >= 2 && openCounter >= 2)
                        done = true;
                    if (characterIndex == text.Length && !done)
                    {
                        characterIndex = initialCharacterIndex;
                        foundTag = false;
                        done = true;
                    }
                }            
                if (foundTag)
                {
                    string tagOpen = text.Substring(firstTagStart, firstTagEnd - firstTagStart + 1);
                    string tagClose = text.Substring(secondTagStart, secondTagEnd - secondTagStart + 1);
                    textArea.text += tagOpen;
                    int newIndex = textArea.text.Length;
                    textArea.text += tagClose;
                    for (int i = 0; i < richText.Length; i++)
                    {                                        
                        yield return new WaitForSeconds(totalDuration / text.Length);
                        textArea.text = textArea.text.Insert(newIndex + i, "" + richText[i]);
                    }  
                }
                else
                {
                    textArea.text += "<";
                }
            }
            else
            {
                yield return new WaitForSeconds(totalDuration/text.Length);
                textArea.text += text[characterIndex];
                characterIndex++;
            }
        }
        textArea.text += "\n";
    }
        
}

/*
Especificar string
Especificar tiempo entre letras
Especificar tiempo de espera antes
Especificar tiempo de espear después
*/
