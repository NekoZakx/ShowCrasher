using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	public double hp;
	private float waveSpeed = -3f;
	private float bouncePower = 10f;
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
		WaveMaintenance ();
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
		//Debug.Log("Haut Collision");
		playerHautCollision = true;
		 
	}

	public void setCoteCollision()
	{		
		//Debug.Log ("Cote Collider");
		playerCoteCollision = true;
		script.decreaseScore(10);
	}

	public void setWeaponCollision()
	{
		//Debug.Log("Collision Player Weapon");
		GlobalVariable.crowdGetOut = true;
		GlobalVariable.nbWaveDestroy++;
		playerWeaponCollision = true;
		script.inscreaseScore(100);
	}

	public void disableCollision()
	{
		transform.GetChild (0).GetComponent<BoxCollider2D> ().enabled = false;
		transform.GetChild (1).GetComponent<BoxCollider2D> ().enabled = false;
	}
	void WaveMaintenance()
	{
		if (transform.position.x < -30.0f)
		{
			Destroy (gameObject);
		}

		if(transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("wave_explosion"))//this.animator.GetCurrentAnimatorStateInfo(0).IsName("wave_explosion"))
		{
			Destroy(this.gameObject);
		}

	}

	public void jumpOnWave()
	{
		GetComponent<Animator>().SetBool("Wave_jumped_on", true);
	}

	public void dommageWave(float dommageRecu)
	{	
		//Debug.Log("HP : " + hp + " Dommage : " + dommageRecu );
		hp -= dommageRecu;
		if(hp <= 0)
		{
			GetComponent<Animator>().SetBool("Kill_wave", true);
		}
	}
}
