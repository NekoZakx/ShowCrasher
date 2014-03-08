using UnityEngine;
using System.Collections;

public class WaveCoteCollider : MonoBehaviour 
{
	
	private WaveScript script;

	void Start () 
	{
		script = transform.parent.gameObject.GetComponent<WaveScript>();
	}
		
	void OnCollisionEnter2D(Collision2D collision) 
	{			
		if(collision.gameObject.tag == "Player") 
		{		
 			script.setCoteCollision();
		}
	}
}


