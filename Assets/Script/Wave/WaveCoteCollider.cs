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
			
			//Debug.Log(Time.time);
			//Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag == "stateRun");
			script.setCoteCollision();
			collision.gameObject.GetComponent<PlayerController>().HitWall();
			script.disableCollision();
		}
		
		if(collision.gameObject.tag == "GuitarCollision") 
		{
			script.disableCollision();
			script.setWeaponCollision();
			script.dommageWave(collision.gameObject.transform.parent.gameObject.GetComponent<PlayerController>().attackPower);
		}
	}
}


