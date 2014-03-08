using UnityEngine;
using System.Collections;

public class WaveCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
