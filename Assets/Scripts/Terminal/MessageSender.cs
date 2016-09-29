using UnityEngine;
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
            msg.message = constants.switchMessage;
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
            terminal.WriteToTerminal(messages[i].message, messages[i].totalDuration, messages[i].beforeTime, messages[i].afterTime);
        }
    }        
        
}
