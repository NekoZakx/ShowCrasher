using UnityEngine;
using System.Collections;

public class WaveCoteCollider : MonoBehaviour 
{
	
	public WaveScript script;
	
	// Use this for initialization
	void Start () 
	{
		script = transform.parent.gameObject.GetComponent<WaveScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnCollisionEnter2D(Collision2D collision) 
	{			
		if(collision.gameObject.tag == "Player") 
		{		
			script.setCoteCollision();
		}
	}
}


