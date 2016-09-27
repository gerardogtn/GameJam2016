using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour {

    [SerializeField]
    string onMessage;
    [SerializeField]
    string offMessage;
    [SerializeField]
    bool isOn;
    [SerializeField]
    float resetTime;
    public List<GameObject> targets = new List<GameObject>();
    public enum ResetType {Never, OnUse, Timed, Immediately}
    public ResetType resetType = ResetType.OnUse;


    public void TurnOn()
    {
        if (!isOn)
            setState(true);
    }

    public void TurnOff()
    {
        if (isOn && resetType != ResetType.Never && resetType != ResetType.Timed)
            setState(false);
    }

    public void TimedReset()
    {
        setState(false);
    }

    public void Toggle()
    {
        if (isOn)
            TurnOff();
        else
            TurnOn();
    }

    void setState(bool _isOn)
    {
        isOn = _isOn;
        if (isOn)
        {
            if (targets.Count > 0 && !string.IsNullOrEmpty(onMessage))
            {
                targets.ForEach(n => n.SendMessage(onMessage));
            }
            if (resetType == ResetType.Immediately)
                TurnOff();
            else if (resetType == ResetType.Timed)
            {
                Invoke("TimedReset", resetTime);
            }
        }
        else
        {
            if (targets.Count > 0 && !string.IsNullOrEmpty(offMessage))
            {
                targets.ForEach(n => n.SendMessage(offMessage));
            }
        }
    }
}
