using UnityEngine;
using System.Collections;

public class ColoredBlock : ColorReceiver {

	public Colors color; 

	public override void Start() {
		base.Start ();
		this.gameObject.SetActive (false);
	}

	public override void OnColorReceived(Colors color) {
		this.gameObject.SetActive (color == this.color);
	}
}
