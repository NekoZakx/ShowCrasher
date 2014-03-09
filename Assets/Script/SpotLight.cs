using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;

public class SpotLight : MonoBehaviour {

	private GameObject[] mySpotLight;
	private float coolDown1 = 2.0f;
	private float coolDown2 = 4.0f;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

	// Use this for initialization
	void Start () {
		mySpotLight = GameObject.FindGameObjectsWithTag ("SpotLight");
		Debug.Log ("LENGHT: " + mySpotLight.Length);
	}
	
	// Update is called once per frame
	void Update () {

		coolDown1 -= Time.deltaTime;
		if(coolDown1 <= 0.0f)
		{
			mySpotLight[RollDice(3)].renderer.enabled = false;
			coolDown1 = 2.0f;
		}
		else if(coolDown1 <= 1.0f)
		{
			mySpotLight[RollDice(3)].renderer.enabled = true;
		}


		switch(RollDice(4))
		{
			case 1:
				if(mySpotLight[0].gameObject.transform.eulerAngles.z == 355)
				{
					mySpotLight[0].gameObject.transform.Rotate(new Vector3(0,0,350));
				}
				else
				{
				
					mySpotLight[0].gameObject.transform.Rotate(new Vector3(0,0,355));
				}
				break;
			case 2:
			mySpotLight[1].gameObject.transform.rotation = Quaternion.AngleAxis(20,Vector3.up);
				break;
			case 3:
			mySpotLight[2].gameObject.transform.rotation = Quaternion.AngleAxis(30,Vector3.up);
				break;
			case 4:
			mySpotLight[3].gameObject.transform.rotation = Quaternion.AngleAxis(40,Vector3.up);
				break;
			default:
				break;
			
		}

		/*coolDown2 -= Time.deltaTime;
		if(coolDown2 <= 0.0f)
		{
			mySpotLight[1].renderer.enabled = false;
			coolDown2 = 4.0f;
		}
		else if(coolDown2 <= 2.0f)
		{
			mySpotLight[1].renderer.enabled = true;
		}*/
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
}
