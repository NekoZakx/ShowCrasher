using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

public class CrowdGetOut : MonoBehaviour {

	private GameObject[] myCrowd;
	private float posX = 0;
	private int cpt = 0;
	protected Animator playerAnimation;

	// Use this for initialization
	void Start () {

		myCrowd = GameObject.FindGameObjectsWithTag ("Crowd");
		posX = -5.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GlobalVariable.crowdGetOut && cpt <= myCrowd.Length-1)
		{
			GlobalVariable.crowdGetOut = false;
			myCrowd[cpt].rigidbody2D.velocity = new Vector2(posX, 0);
			playerAnimation = myCrowd[cpt].GetComponent<Animator>();
			playerAnimation.SetBool("GTFO", true);
			cpt++;
		}
		if(cpt <= myCrowd.Length-1)
		{
			crowdMaintenance(myCrowd.Length-1);
		}
		
	}

	void crowdMaintenance(int pos)
	{
		if (myCrowd[pos].transform.position.x < -30.0f)
		{
			for(int i = 0; i < myCrowd.Length; i++)
			{
				Destroy(myCrowd[i].gameObject);
			} 
		}
	}
}
