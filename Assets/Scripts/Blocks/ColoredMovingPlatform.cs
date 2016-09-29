using UnityEngine;
using System.Collections;

public class ColoredMovingPlatform : ColorReceiver {

	public Colors color;
	private LineRenderer lineRenderer;
	private Renderer meshRenderer;
	private Collider meshCollider;

	public override void Start () {
		base.Start ();
		lineRenderer = this.gameObject.GetComponentInParent<LineRenderer> ();
		meshRenderer = this.gameObject.GetComponent<MeshRenderer> ();
		meshCollider = this.gameObject.GetComponent<BoxCollider> ();
		Disable ();
	}

	public override void OnColorReceived(Colors color) {
		Debug.Log (color.getString ());
		if (this.color == color) {
			Enable ();
		} else {
			Disable ();
		}
	}


	private void Enable() {
		lineRenderer.enabled = true; 
		meshCollider.enabled = true;
		meshRenderer.enabled = true;
	}

	private void Disable() {
		lineRenderer.enabled = false;
		meshCollider.enabled = false;
		meshRenderer.enabled = false;
	}
}
