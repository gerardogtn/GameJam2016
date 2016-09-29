using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour {

    [SerializeField]
    protected string onMessage;
    [SerializeField]
    protected string offMessage;
    [SerializeField]
    protected bool isOn;
    [SerializeField]
    protected float resetTime;
    public List<GameObject> targets = new List<GameObject>();
    public enum ResetType {Never, OnUse, Timed, Immediately}
    public ResetType resetType = ResetType.OnUse;


    public virtual void TurnOn()
    {
		if (!isOn)
			setActive ();
    }

    public virtual void TurnOff()
    {
		if (isOn && resetType != ResetType.Never && resetType != ResetType.Timed)
			setInactive ();
    }

    public void TimedReset()
    {
		setInactive ();
    }

    public virtual void Toggle()
    {
		if (isOn) {
			TurnOff ();
		} else {
			TurnOn ();
		}
    }

	protected virtual void setActive() {
		isOn = true; 
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

    protected virtual void setInactive() {
		isOn = false;
		if (targets.Count > 0 && !string.IsNullOrEmpty(offMessage)) {
			targets.ForEach (n => n.SendMessage(offMessage));
		}
    }
}
