using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;

public class CrowdSpawn : MonoBehaviour {

	public GameObject crowdType_1;
	public GameObject crowdType_2;
	public GameObject crowdType_3;
	public GameObject crowdType_4;
	private GameObject crowdSpawn;
	private GameObject crowdChose;
	private Vector3 initCrowdPosition;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
	private float timer;
	private float timeSpawn = 0.1f;

	void Start () 
	{
		initCrowdPosition = transform.position; 
	}

	void Update () {
	
	}

	void FixedUpdate()
	{
		if(!GlobalVariable.endOfGame)
		{
			timer += Time.deltaTime;
			if(timer >= timeSpawn)
			{


				switch(RollDice(4))
				{
				case 1:
					crowdChose = crowdType_1;
					break;
				case 2:
					crowdChose = crowdType_2;
					break;
				case 3:
					crowdChose = crowdType_3;
					break;
				case 4:
					crowdChose = crowdType_4;
					break;
				default:
					break;
					
				}

				switch(RollDice(4))
				{
				case 1:
					initCrowdPosition.y += RollDice(16) + 2;
					initCrowdPosition.z += initCrowdPosition.y * 0.01f;
					crowdSpawn = (GameObject)Instantiate(crowdChose, initCrowdPosition , Quaternion.identity);
					crowdSpawn.GetComponent<crowdAction>().setVitesse(-3);
					crowdSpawn.GetComponent<crowdAction>().setNbWaveDepart(RollDice(40));
					break;
				case 2:
					initCrowdPosition.y += RollDice(16) + 2;
					initCrowdPosition.z += initCrowdPosition.y * 0.01f;
					crowdSpawn = (GameObject)Instantiate(crowdChose, initCrowdPosition , Quaternion.identity);
					crowdSpawn.GetComponent<crowdAction>().setVitesse(-3);
					crowdSpawn.GetComponent<crowdAction>().setNbWaveDepart(RollDice(30));
					break;

				case 3:
					initCrowdPosition.y += RollDice(16) + 2;
					initCrowdPosition.z += initCrowdPosition.y * 0.01f;
					crowdSpawn = (GameObject)Instantiate(crowdChose, initCrowdPosition , Quaternion.identity);
					crowdSpawn.GetComponent<crowdAction>().setVitesse(-3);
					crowdSpawn.GetComponent<crowdAction>().setNbWaveDepart(RollDice(25));
					break;
				case 4:
					initCrowdPosition.y += RollDice(16) + 2;
					initCrowdPosition.z += initCrowdPosition.y * 0.01f;
					crowdSpawn = (GameObject)Instantiate(crowdChose, initCrowdPosition , Quaternion.identity);
					crowdSpawn.GetComponent<crowdAction>().setVitesse(-3);
					crowdSpawn.GetComponent<crowdAction>().setNbWaveDepart(RollDice(20));
					break;

				default:
					break;
				
				}
				initCrowdPosition = transform.position; 
				timer = 0.0f;
			}
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
}
