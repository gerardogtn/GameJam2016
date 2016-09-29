using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ActualColorReceiver : ColorReceiver {

	public Sprite WhiteSprite;
	public Sprite RedSprite;
	public Sprite GreenSprite;
	public Sprite BlueSprite;
	public Sprite CyanSprite;
	public Sprite YellowSprite;
	public Sprite MagentaSprite;
	public Sprite BlackSprite;

	private Image image;

	public override void Start() {
		base.Start ();
		image = GetComponent<Image> ();
		image.sprite = BlackSprite;
	}

	public override void OnColorReceived(Colors color) {
		switch (color) {
		case Colors.White:
			image.sprite = WhiteSprite;
			break;
		case Colors.Red:
			image.sprite = RedSprite;
			break;
		case Colors.Green:
			image.sprite = GreenSprite;
			break;
		case Colors.Blue:
			image.sprite = BlueSprite;
			break;
		case Colors.Cyan:
			image.sprite = CyanSprite;
			break;
		case Colors.Yellow: 
			image.sprite = YellowSprite;
			break;
		case Colors.Magenta:
			image.sprite = MagentaSprite;
			break;
		case Colors.Black:
			image.sprite = BlackSprite;
			break;
		default:
			break;
		}
	}
}
