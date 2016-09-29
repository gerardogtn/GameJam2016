using UnityEngine;
using System.Collections;

public class LiteSwitch : Switch {

	protected override void setActive ()
	{
		if (resetType == ResetType.Immediately)
			TurnOff();
		else if (resetType == ResetType.Timed)
		{
			Invoke("TimedReset", resetTime);
		}
	}

	protected override void setInactive() {
		
	}
}
