using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public bool jump = false;

	public float jumpForce = 5.0f;
	
	private bool isFalling = false;
	private bool grounded = false;

	void Awake()
	{
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Jump") && grounded) 
		{
			jump = true;
			grounded = false;
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
	}
}
