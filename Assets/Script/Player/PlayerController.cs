using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool jump = false;
	private bool isAttacking = false;
	public float jumpForce;
	public float attackPower;
	private bool isInTheAir = false;
	
	private bool isFalling = false;
	private bool grounded = false;
	protected Animator playerAnimation;
	public float timer = 0.2f;
	public float staggerTimmer = 0.0f;

	public AudioSource JumpSrc;
	public AudioSource LandSrc;
	public AudioSource BounceSrc;
	public AudioSource HitWallSrc;
	public AudioSource AttackSrc;


	void Awake()
	{
		//audioSrc = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () 
	{
		playerAnimation = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		if(!GlobalVariable.endOfGame)
		{
			timer -= Time.deltaTime;

			if(staggerTimmer <= 0.0f)
			{
				playerAnimation.SetBool ("Stagger", false);
				if (Input.GetButtonDown ("Jump") && grounded) 
				{
					jump = true;
					grounded = false;
					playerAnimation.SetBool("Jump", true);
					playerAnimation.SetBool("Grounded", false);
				} 

				if (jump && !grounded) 
				{
					isInTheAir = true;
				}

				if (Input.GetButtonDown ("Enter") && timer <= 0.0f && grounded) 
				{
					isAttacking = true;
					playerAnimation.SetBool ("Attack", true);
					playerAnimation.SetBool("Grounded", true);
					jump = false;
					timer = 0.2f;
				}

				if (grounded) 
				{
					playerAnimation.SetBool("Jump", false);
					playerAnimation.SetBool("Grounded", true);
					jump = false;
					isInTheAir = false;
				}

				/*if(rigidbody2D.velocity.y < 0)
				{
					isFalling = true;
				}
				else
				{
					isFalling = false;
				}*/

				if (Input.GetButtonDown ("Enter") && timer <= 0.0f && isInTheAir) 
				{
					timer = 0.2f;
					isAttacking = true;
					playerAnimation.SetBool ("Attack", true);
					playerAnimation.SetBool("Grounded", false);
					rigidbody2D.velocity = new Vector2 (0, -jumpForce);
				}


				if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("stateAttack"))
				{				
					transform.Find("CollisionGuitar").GetComponent<BoxCollider2D>().enabled = true;
				}
				else
				{				
					transform.Find("CollisionGuitar").GetComponent<BoxCollider2D>().enabled = false;
				}
			}
			else
			{
				staggerTimmer -= Time.deltaTime;
			}
		}
	}
	
	void FixedUpdate()
	{
		if (jump)//Si on peut sauter. 
		{
			rigidbody2D.velocity = new Vector2(0, jumpForce);

			JumpSrc.Play();
			jump = false;
		}

		if (isAttacking)
		{
			AttackSrc.Play();

			isAttacking = false;
			playerAnimation.SetBool ("Attack", false);
		}

		if (rigidbody2D.velocity.y == 0 && isInTheAir) 
		{
			jump = false;
			isInTheAir = false;
			grounded = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Terrain") 
		{

			LandSrc.Play();
			grounded = true;
			jump = false;
		}

	}

	public void Bounce(float _vel)
	{
		rigidbody2D.velocity = new Vector2(0, jumpForce + _vel);
		GlobalVariable.nbJump++;
		BounceSrc.Play();
	}

	public void HitWall()
	{
		playerAnimation.SetBool ("Stagger", true);
		staggerTimmer = 0.2f;
		HitWallSrc.Play();
	}
}
