using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentColorTextReceiver : ColorReceiver {

	public string BaseText = "Current color: "; 
	public string NoColorText = "No color active"; 

	private Text Text;

	public override void Start () {
		base.Start ();
		Text = GetComponent<Text> ();
		Text.text = NoColorText;
	}

	public override void OnColorReceived(Colors color) {
		switch (color) {
		case Colors.Black: 
			Text.text = NoColorText;
			break;
		default:
			Text.text = BaseText + color.getString ();
			break;
		}
	}
}
