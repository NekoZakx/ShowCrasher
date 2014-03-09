using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

public class Score : MonoBehaviour 
{
	private int score;
	public float timer = 6.0f;
	public Font myFont;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
	private Stats playerStats;
	private int nbWaveDestroy;

	// Use this for initialization
	void Start () {
		score = 0;
		nbWaveDestroy = 0;
		playerStats = new Stats ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (score - 30 > 0 && timer <= 0) 
		{
			score -= 30 + RollDice(9);
			timer = 6.0f;
		} 
		else if (score - 30 < 0) 
		{
			score = 0;
		}
	}

	public void inscreaseScore(int newScore)
	{
		nbWaveDestroy++;
		score += nbWaveDestroy*newScore;
	}

	public void decreaseScore(int newScore)
	{
		nbWaveDestroy = 0;
		if (score - newScore > 0) 
		{
			score -= newScore;
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

	void OnGUI()
	{
		if(!playerStats.endOfGame)
		{
			GUI.skin.font = myFont;
			GUI.Label(new Rect(0,0,Screen.width,Screen.height), "Viewers: " + score);
		}
	}
}
