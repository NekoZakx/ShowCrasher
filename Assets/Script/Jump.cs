using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public bool jump = false;

	public float jumpForce = 5.0f;

	private Transform groundDetector;
	private bool grounded = false;
	private bool isFalling = false;

	void Awake()
	{
		groundDetector = transform.Find("GroundDetector");
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundDetector.position, 1 << LayerMask.NameToLayer("Terrain"));//Ligne qui check si on a touché le sol.

		if (Input.GetButtonDown("Jump") && grounded) 
		{
			jump = true;
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
}
