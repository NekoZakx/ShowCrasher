using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.contacts[0].collider.name == "CoteCollider") 
		{

		}
	}
}
