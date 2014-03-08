using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	private float waveSpeed = -3f;
	private float bouncePower = 100f;
	private bool playerHautCollision = false;
	private bool playerCoteCollision = false;
	private bool playerWeaponCollision = false;

	private BoxCollider2D hautCollider;

	private Score script;


	
	// Use this for initialization
	//lol
	void Start () 
	{	
		script = GameObject.FindGameObjectWithTag("Terrain").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		rigidbody2D.velocity = new Vector2 (waveSpeed, 0f);
	}

	public void SetVelocity(float _vel)
	{
		waveSpeed = _vel;
	}

	public float BouncePower
	{
		get{
			return bouncePower;
		}
		set{
			bouncePower = value;
		}
	}

	public void setHautCollision()
	{		
		Debug.Log("Haut Collision");
		playerHautCollision = true;
		script.inscreaseScore(100);
		 
	}

	public void setCoteCollision()
	{		
		//Debug.Log ("Cote Collider");
		playerCoteCollision = true;
		script.decreaseScore(10);
	}

	public void setWeaponCollision()
	{
		Debug.Log("Collision Player Weapon");
		playerWeaponCollision = true;
		script.inscreaseScore(100);
	}
	
}
