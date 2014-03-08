using UnityEngine;
using System.Collections;

//Simply attach me to an object to be collected

[RequireComponent(typeof(SpriteRenderer))]
public class Collectable : MonoBehaviour {

	public string nameOfObject;
	private float velocity;
	private float CollectableSpeed = -3f;

	void FixedUpdate()
	{
		//rigidbody.velocity = new Vector3(velocity,0,0);
		rigidbody2D.velocity = new Vector2 (CollectableSpeed, 0f);
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
	}

}
