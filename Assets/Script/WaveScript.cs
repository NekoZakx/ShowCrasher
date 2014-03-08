using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	float waveSpeed = -3f;
	
	// Use this for initialization
	//lol
	void Start () 
	{	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		Debug.Log ("test");
		rigidbody2D.velocity = new Vector2 (waveSpeed, 0f);
	}
	
	void OnCollisionEnter2D(Collision2D collision) 
	{	

		if(collision.gameObject.tag == "Terrain") 
		{		
			Debug.Log("Collision Terrain");
		}
		
		if(collision.gameObject.tag == "Player") 
		{		
			Debug.Log("Collision Player");
		}
		
		if(collision.gameObject.tag == "PlayerWeapon") 
		{		
			Debug.Log("Collision Player Weapon");
		}
	}

}
