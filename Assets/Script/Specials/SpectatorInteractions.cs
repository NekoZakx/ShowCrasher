using UnityEngine;
using System.Collections;

public class SpectatorInteractions : MonoBehaviour {

	public float timeToWaitUntilNextAnim = 10f;
	private float time = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Progress timer
		time += Time.deltaTime;

		if(time >= timeToWaitUntilNextAnim)
		{
			time = 0f;
			//TODO Play Idle Animation!
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//Collide with light
		if(collider.gameObject.tag == "LightSpot")
		{
			//TODO Trigger special animation!
		}
	}
}
