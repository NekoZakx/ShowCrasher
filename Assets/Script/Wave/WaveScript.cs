using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	private float waveSpeed = -3f;
	private bool playerHautCollision = false;
	private bool playerCoteCollision = false;
	private bool playerWeaponCollision = false;

	private BoxCollider2D hautCollider;
	
	// Use this for initialization
	//lol
	void Start () 
	{	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		rigidbody2D.velocity = new Vector2 (waveSpeed, 0f);
	}

	public void setHautCollision()
	{		
		Debug.Log("Haut Collision");
		playerHautCollision = true;
	}

	public void setCoteCollision()
	{		
		Debug.Log ("Cote Collider");
		playerCoteCollision = true;
	}

	public void setWeaponCollision()
	{
		Debug.Log("Collision Player Weapon");
		playerWeaponCollision = true;
	}
	
}
