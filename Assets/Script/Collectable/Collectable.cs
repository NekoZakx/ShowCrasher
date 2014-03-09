using UnityEngine;
using System.Collections;

//Simply attach me to an object to be collected

[RequireComponent(typeof(SpriteRenderer))]
public class Collectable : MonoBehaviour {

	public string nameOfObject;
	private float velocity = -3f;

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2(velocity,0);
		CollectableMaintenance ();
	}

	public void SetVelocity(float _vel)
	{
		velocity = _vel;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//Collide with player
		if(collider.gameObject.tag == "Player")
		{
			IAmCollected(collider.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Collide with player
		if(collision.gameObject.tag == "Player")
		{

			IAmCollected(collision.gameObject);
		}
	}

	void IAmCollected(GameObject Player)
	{
		//TODO Add to player inventory
		Player.GetComponent<PlayerInventory>().AddToInventory(new ObjectParam(nameOfObject, gameObject.GetComponent<SpriteRenderer>().sprite));
		Destroy(gameObject);
		CalculateAtkPower (Player);
	}
	void CollectableMaintenance()
	{
		if (transform.position.x < -30.0f)
		{
			Destroy (gameObject);
		}
	}
	void CalculateAtkPower(GameObject Player)
	{
		int power = 0;
		power = (Player.GetComponent<PlayerInventory> ().nbTriangle * 1) + (Player.GetComponent<PlayerInventory> ().nbCymbal * 3) + (Player.GetComponent<PlayerInventory> ().nbTrumpet * 5) + 5;

		Player.GetComponent<PlayerController> ().attackPower = power;
	}

}
