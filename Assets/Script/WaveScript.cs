using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	float waveSpeed = -3f;
	
	// Use this for initialization
	//lol
	void Start () 
	{
		
		//gameObject.rigidbody2D.AddForce(new Vector2(waveSpeed, 0f));
		


	}
	
	// Update is called once per frame
	void Update () 
	{	
		gameObject.rigidbody2D.velocity = new Vector2 (waveSpeed, 0f);
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{				
		if(collision.gameObject.tag == "Terrain") 
		{
			Debug.Log("Collision Terrain");
		}
	}
}
