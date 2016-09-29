using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GreenLightReceiver: ColorReceiver {

	public Sprite EnabledSprite; 
	public Sprite DisabledSprite;
	private Image Image;

	public override void Start () {
		base.Start ();
		Image = GetComponent<Image> ();
		Image.sprite = DisabledSprite;
	}

	public override void OnColorReceived(Colors color) {
		if (color == Colors.Blue || color == Colors.Yellow || color == Colors.Cyan || color == Colors.White) {
			this.Image.sprite = EnabledSprite;
		} else {
			this.Image.sprite = DisabledSprite;
		}
	}
}
