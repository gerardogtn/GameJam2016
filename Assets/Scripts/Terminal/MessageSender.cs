﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageSender : MonoBehaviour {

    AutoWrite terminal;
    [System.Serializable]   
    public struct MessageParams{        
        public string message;
        public float totalDuration;
        public float beforeTime;
        public float afterTime;
    };
        
    public List<MessageParams> messages = new List<MessageParams>();

    bool sentMessages;

    void Start()
    {
        terminal = AutoWrite.instance;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && !sentMessages)
        {
            sendMessages();
        }
    }

    void sendMessages()
    {
        sentMessages = true;
        for (int i = 0; i < messages.Count; i++)
        {
            terminal.WriteToTerminal(messages[i].message, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
        }
    }        
        
}