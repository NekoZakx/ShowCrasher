using UnityEngine;
using System.Collections;

public class WaveHautCollider : MonoBehaviour 
{
	
	private WaveScript script;
	
	// Use this for initialization
	void Start () 
	{
		script = transform.parent.gameObject.GetComponent<WaveScript>();
	}


	void OnTriggerEnter2D(Collider2D collision)
	{		
		if(collision.gameObject.tag == "Player") 
		{	
			script.setHautCollision();
			collision.gameObject.GetComponent<PlayerController>().Bounce(transform.parent.gameObject.GetComponent<WaveScript>().BouncePower);
			script.disableCollision();
			script.jumpOnWave();

		}
		
		if(collision.gameObject.tag == "GuitarCollision") 
		{
			script.disableCollision();
			script.setWeaponCollision();
			script.killWave();
		}
	}
}
