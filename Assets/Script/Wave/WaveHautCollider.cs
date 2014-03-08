using UnityEngine;
using System.Collections;

public class WaveHautCollider : MonoBehaviour {

	private WaveScript script;

	// Use this for initialization
	void Start () 
	{
		script = transform.parent.gameObject.GetComponent<WaveScript>();
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{		
		if(collision.gameObject.tag == "Player") 
		{		
			script.setHautCollision();
			collision.gameObject.GetComponent<PlayerController>().Bounce(transform.parent.gameObject.GetComponent<WaveScript>().BouncePower);
		}
		
		if(collision.gameObject.tag == "PlayerWeapon") 
		{		
			script.setWeaponCollision();
		}
	}
}
