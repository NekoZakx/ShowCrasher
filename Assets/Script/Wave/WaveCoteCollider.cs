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
		{	//Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag == "stateRun");
			if(GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("stateAttack"))
			{
				// Ici permet de diminuer la vie et de mettre la wave a jour
				script.disableCollision();
				script.setWeaponCollision();
			}
			else
			{
				script.setCoteCollision();
				collision.gameObject.GetComponent<PlayerController>().HitWall();
				script.disableCollision();
			}
		}
	}
}


