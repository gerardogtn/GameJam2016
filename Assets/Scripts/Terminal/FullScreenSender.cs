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
            if (i + 1 == messages.Count && messages.Count != 1)
            {
                if (Input.GetJoystickNames().Length > 0)
                    terminal.WriteToTerminal(messages[i].controllerMessage != "" ? messages[i].controllerMessage : messages[i].keyboardMessage, false, false, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
                else
                    terminal.WriteToTerminal(messages[i].keyboardMessage, false, false, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
            }
            else if (messages.Count == 1)
            {
                if (Input.GetJoystickNames().Length > 0)
                    terminal.WriteToTerminal(messages[i].controllerMessage != "" ? messages[i].controllerMessage : messages[i].keyboardMessage, false, true, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
                else
                    terminal.WriteToTerminal(messages[i].keyboardMessage, false, true, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);            
            }
            else
            {
                if (Input.GetJoystickNames().Length > 0)
                    terminal.WriteToTerminal(messages[i].controllerMessage != "" ? messages[i].controllerMessage : messages[i].keyboardMessage, true, false, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
                else
                    terminal.WriteToTerminal(messages[i].keyboardMessage, true, false, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);   
            }                          
        }
    }    
}
