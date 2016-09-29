using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageSender : MonoBehaviour {

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
    [SerializeField]
    bool isSwitch;

    Constants constants;

    void Start()
    {
        constants = Constants.instance;
        terminal = AutoWrite.instance;
        if (isSwitch)
        {
            MessageParams msg = new MessageParams();
            msg.keyboardMessage = constants.switchKeyboardMessage;
            msg.controllerMessage = constants.switchControllerMessage;
            msg.totalDuration = constants.switchMessageDuration;
            messages.Add(msg);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.isTrigger)
        {
            if (!sentMessages && !isSwitch)
            {
                sendMessages();
                sentMessages = true;
            }
            if (isSwitch)
            {               
                sendMessages();
            }
        }
    }

    void sendMessages()
    {        
        for (int i = 0; i < messages.Count; i++)
        {
            if(Input.GetJoystickNames().Length > 0)
                terminal.WriteToTerminal(messages[i].controllerMessage != "" ? messages[i].controllerMessage : messages[i].keyboardMessage , messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
            else
                terminal.WriteToTerminal(messages[i].keyboardMessage, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
        }
    }        
        
}
