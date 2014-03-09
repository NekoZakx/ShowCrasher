using UnityEngine;
using System.Collections;

public class SpotLight : MonoBehaviour {

	private GameObject[] mySpotLight;
	private float coolDown1 = 1.0f;
	private float coolDown2 = 2.0f;

	// Use this for initialization
	void Start () {
		mySpotLight = GameObject.FindGameObjectsWithTag ("SpotLight");
	}
	
	// Update is called once per frame
	void Update () {
		/*coolDown1 -= Time.deltaTime;
		if(coolDown1 <= 0)
		{
			mySpotLight[0].renderer.enabled = false;
			coolDown1 = 1.0f;
		}
		else if(coolDown1 > 0)
		{
			mySpotLight[0].renderer.enabled = true;
		}

		coolDown2 -= Time.deltaTime;
		if(coolDown2 <= 0)
		{
			mySpotLight[1].renderer.enabled = false;
			coolDown1 = 2.0f;
		}
		else if(coolDown2 > 0)
		{
			mySpotLight[1].renderer.enabled = true;
		}*/
	}
}
