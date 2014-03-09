using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

public class Chat : MonoBehaviour {

	private ArrayList allChatMessage;
	private ArrayList positiveMessage;
	private ArrayList negativeMessage;
	private ArrayList name;
	private CustomScrollView chat;
	private Vector2 scrollPos;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

	// Use this for initialization
	void Start () {
		allChatMessage = new ArrayList ();
		positiveMessage = new ArrayList ();
		negativeMessage = new ArrayList ();
		name = new ArrayList ();

		positiveMessage.Add ("So cool, big performance!");
		positiveMessage.Add ("YEAH ROCK ON!");
		positiveMessage.Add ("Best show ever!");

		negativeMessage.Add ("Crappy show!");
		negativeMessage.Add ("You are SO BAD!");
		negativeMessage.Add ("FAIL BIG NOOB!");

		name.Add ("Pickles123: ");
		name.Add ("Bobette505: ");
		name.Add ("LifeIsHard342: ");
		name.Add ("Orangina34: ");

		chat = new CustomScrollView ();

		scrollPos = Vector2.zero;

		allChatMessage.Add ("Orangina34: Hello everyone :)");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public int GetMessagesHeight(ArrayList messages,float maxWidth)
	{
		int retval = 0;
		Vector2 currentMessageSize;
		foreach(string msg in messages)
		{
			currentMessageSize = GUI.skin.label.CalcSize(new GUIContent(msg));
			retval += ((int)Mathf.Ceil(currentMessageSize.x/maxWidth) * (int)currentMessageSize.y + 4);
		}
		return retval;
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
		if(GlobalVariable.showPositiveMessage)
		{
			GlobalVariable.showPositiveMessage = false;
			allChatMessage.Add(name[RollDice(System.Convert.ToByte(name.Count))-1].ToString() + positiveMessage[RollDice(System.Convert.ToByte(positiveMessage.Count))-1].ToString());
		}
		else if(GlobalVariable.showNegativeMessage)
		{
			GlobalVariable.showNegativeMessage = false;
			allChatMessage.Add(name[RollDice(System.Convert.ToByte(name.Count))-1].ToString() + negativeMessage[RollDice(System.Convert.ToByte(negativeMessage.Count))-1].ToString());
		}
		
		scrollPos = chat.BeginScrollView (new Rect (Screen.width - 10 - 300, 10, 300, 300), scrollPos, GetMessagesHeight(allChatMessage, 500), Vector4.zero);
		foreach(string c in allChatMessage)
		{
			GUILayout.Label(c,GUILayout.MaxWidth(300));
		}
		chat.EndScrollView();
		GUI.Box (new Rect (Screen.width - 10 - 300, 10, 300, 300), "");
		scrollPos.y++;
	}
}
