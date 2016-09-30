using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FullScreenSender : MonoBehaviour {

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

    bool sentMessages;

    void Start()
    {
        terminal = AutoWrite.instance;
        sendMessages();
    }
        
    void sendMessages()
    {        
        sentMessages = true;
        for (int i = 0; i < messages.Count; i++)
        {
            if(Input.GetJoystickNames().Length > 0)
                terminal.WriteToTerminal(messages[i].controllerMessage != "" ? messages[i].controllerMessage : messages[i].keyboardMessage , messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
            else
                terminal.WriteToTerminal(messages[i].keyboardMessage, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
        }
    }    
}
