using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool jump = false;

	public float jumpForce = 10.0f;
	
	private bool isFalling = false;
	private bool grounded = false;
	protected Animator jumpAnimation;

	void Awake()
	{
	}

	// Use this for initialization
	void Start () 
	{
		jumpAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		Debug.Log ("testestetes");
		if (Input.GetButtonDown("Jump") && grounded) 
		{
			jump = true;
			grounded = false;
			jumpAnimation.SetBool("Jump", true);
			jumpAnimation.SetBool("Grounded", false);
		}

		if (grounded) 
		{
			jumpAnimation.SetBool("Jump", false);
			jumpAnimation.SetBool("Grounded", true);
		}

		if(rigidbody2D.velocity.y < 0)
		{
			isFalling = true;
		}
		else
		{
			isFalling = false;
		}
	}

	void FixedUpdate()
	{
		if (jump)//Si on peut sauter. 
		{
			rigidbody2D.velocity = new Vector2(0, jumpForce);
			jump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Terrain") 
		{
			grounded = true;
		}

		if (collision.contacts[0].collider.name == "HautCollider") 
		{

			rigidbody2D.velocity = new Vector2(0, jumpForce + 2);
		}

		if (collision.contacts[0].collider.name == "CoteCollider") 
		{
			Debug.Log ("Cote Collider");
		}

	}
}
