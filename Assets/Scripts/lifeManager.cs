using UnityEngine;
using System.Collections;

public class lifeManager : MonoBehaviour {
	private float nextActionTime = 0.0f;
	public float period =1;
	float posy = 485.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime) {
			nextActionTime += period;
			// execute block of code here
			float size = transform.localScale.y;
			if(size <= 0 )
			{
				print("Muerto");
			}
			else
			{
				float newsize = size - 0.001f;
				transform.localScale = new Vector2 (1, newsize);
				posy -= 0.285f;
				transform.position = new Vector2 (91, posy);
			}
		}
	}
}
