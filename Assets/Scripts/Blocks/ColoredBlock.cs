using UnityEngine;
using System.Collections;

public class ColoredBlock : ColorReceiver {

	public Colors color; 

	public override void OnColorReceived(Colors color) {
		Debug.Log (color.getString());
		this.gameObject.SetActive (color == this.color);
	}
}
