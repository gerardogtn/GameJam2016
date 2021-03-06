﻿using UnityEngine;
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

    AudioManager audioManager;

    public CoroutineQueue coroutineQueue;

    public static AutoWrite instance = null;

    void Awake()
    {
        coroutineQueue = new CoroutineQueue(this);
        coroutineQueue.StartLoop();
		Application.targetFrameRate = 300;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void OnLevelWasLoaded()
    {
        textArea = GameObject.FindGameObjectWithTag("terminalText").gameObject.GetComponent<Text>();
        coroutineQueue = new CoroutineQueue(this);
        coroutineQueue.StartLoop();
    }

	void Start(){
		audioManager = AudioManager.instance;
	}

    public void WriteToTerminal(string text, bool newLine, float? _totalDuration = null ,  float? _waitTimeBefore = null, 
        float? _waitTimeAfter = null)
    {
        float _totalDurationInit = _totalDuration ?? totalDurationDefault;
        float _waitTimeBeforeInit = _waitTimeBefore ?? waitTimeBeforeDefault;
        float _waitTimeAfterInit = _waitTimeAfter ?? waitTimeAfterDefault;

        if(_waitTimeBeforeInit != 0)
            coroutineQueue.EnqueueWait(_waitTimeBeforeInit);
        coroutineQueue.EnqueueAction(WriteString(text, _totalDurationInit, newLine));
        if(_waitTimeAfterInit != 0)
            coroutineQueue.EnqueueWait(_waitTimeAfterInit);
    }

	public void AddAction(IEnumerator action, float waitTime) {
		coroutineQueue.EnqueueWait (waitTime);
		coroutineQueue.EnqueueAction (action);
	}

    IEnumerator WriteString(string text, float totalDuration, bool newLine)
    {
        if (totalDuration == 0)
            totalDuration = totalDurationDefault;
        int characterIndex = 0;
        if(newLine)
            textArea.text += "\n";
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
                        audioManager.PlaySound("terminal");
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
                audioManager.PlaySound("terminal");
                yield return new WaitForSeconds(totalDuration/text.Length);
                textArea.text += text[characterIndex];
                characterIndex++;
            }
        }
        audioManager.StopSound("terminal");
    }
        
}

/*
Especificar string
Especificar tiempo entre letras
Especificar tiempo de espera antes
Especificar tiempo de espear después
*/
