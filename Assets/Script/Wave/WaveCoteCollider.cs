using UnityEngine;
using System.Collections;

public class WaveCoteCollider : MonoBehaviour 
{
	
	private WaveScript script;

	void Start () 
	{
		script = transform.parent.gameObject.GetComponent<WaveScript>();
	}
		
	void OnTriggerEnter2D(Collider2D collision)
	{			
		if(collision.gameObject.tag == "Player") 
		{		
 			script.setCoteCollision();
			collision.gameObject.GetComponent<PlayerController>().HitWall();
			script.disableCollision();
		}
	}
}


