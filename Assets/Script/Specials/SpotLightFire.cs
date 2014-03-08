using UnityEngine;
using System.Collections;

public class SpotLightFire : MonoBehaviour {
	/****************************** SWAG ********************************/

	public float spotTime = 5f;
	public float spotHiddenTime = 5f;
	private float _spotTimer = 0f;
	private float _spotHiddenTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//updateTimers
		if(_spotTimer == 0f)
			_spotHiddenTimer += Time.deltaTime;

		if(_spotHiddenTimer == 0f)
			_spotTimer += Time.deltaTime;

		if(_spotHiddenTimer >= spotHiddenTime)
		{
			_spotHiddenTimer = 0f;
			_spotTimer += Time.deltaTime;

			//TODO Show the light at spectator (Randomize rotation) 
		}

		if(_spotTimer >= spotTime)
		{
			_spotTimer = 0f;
			_spotHiddenTimer += Time.deltaTime;

			//TODO Hide Light by doing a 180 rotation
		}
	}
}
