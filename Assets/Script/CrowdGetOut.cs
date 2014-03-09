using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

public class CrowdGetOut : MonoBehaviour {

	private GameObject[] myCrowd;
	private int rand = 0;
	private int size;
	private float posX = 0;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
	private int cpt = 1;
	protected Animator playerAnimation;

	// Use this for initialization
	void Start () {

		myCrowd = GameObject.FindGameObjectsWithTag ("Crowd");
		//playerAnimation = GetComponent<Animator>();
		size = myCrowd.Length-1;
		Debug.Log ("SIZE: " + myCrowd.Length);
		posX = -2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GlobalVariable.crowdGetOut && cpt <= myCrowd.Length-1)
		{
			Debug.Log("Test");
			GlobalVariable.crowdGetOut = false;
			myCrowd[cpt].rigidbody2D.velocity = new Vector2(posX, 0);
			playerAnimation = myCrowd[cpt].GetComponent<Animator>();
			playerAnimation.SetBool("GTFO", true);
			cpt++;
			Debug.Log("GETOUT " + cpt);

			/*rand = RollDice(System.Convert.ToByte(size))-1;
			GlobalVariable.crowdGetOut = false;
			if(rand <= myCrowd.Length && myCrowd[rand] != null)
			{
				do
				{
					myCrowd[rand].rigidbody2D.velocity = new Vector2(posX, 0);
				}
				while(crowdMaintenance(rand));
				cpt++;
			}
			else
			{
				do
				{
					rand = RollDice(System.Convert.ToByte(size));
				}
				while(rand <= myCrowd.Length && myCrowd[rand] != null);
				do
				{
					myCrowd[rand].rigidbody2D.velocity = new Vector2(posX, 0);
				}
				while(crowdMaintenance(rand));
				cpt++;
			}*/
			/*for(int i = 0; i < myCrowd.Length; i++)
			{

			}*/
		}
		if(cpt <= myCrowd.Length-1)
		{
			crowdMaintenance(myCrowd.Length-1);
		}
		
	}

	public static byte RollDice(byte numberSides)
	{
		if (numberSides <= 0)
			throw new ArgumentOutOfRangeException("numberSides");
		
		// Create a byte array to hold the random value. 
		byte[] randomNumber = new byte[1];
		
		do
		{
			// Fill the array with a random value.
			rngCsp.GetBytes(randomNumber);
		}
		
		while (!IsFairRoll(randomNumber[0], numberSides));
		// Return the random number mod the number 
		// of sides.  The possible values are zero- 
		// based, so we add one. 
		return (byte)((randomNumber[0] % numberSides) + 1);
	}
	
	private static bool IsFairRoll(byte roll, byte numSides)
	{
		// There are MaxValue / numSides full sets of numbers that can come up 
		// in a single byte.  For instance, if we have a 6 sided die, there are 
		// 42 full sets of 1-6 that come up.  The 43rd set is incomplete. 
		int fullSetsOfValues = Byte.MaxValue / numSides;
		
		// If the roll is within this range of fair values, then we let it continue. 
		// In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use 
		// < rather than <= since the = portion allows through an extra 0 value). 
		// 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair 
		// to use. 
		return roll < numSides * fullSetsOfValues;
	}

	void crowdMaintenance(int pos)
	{
		if (myCrowd[pos].transform.position.x < -30.0f)
		{
			Debug.Log("DESTROY");
			for(int i = 0; i < myCrowd.Length; i++)
			{
				Destroy(myCrowd[i].gameObject);
			} 
		}
	}
}
