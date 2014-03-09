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
		positiveMessage.Add ("Yeah! Now it's a good show!");
		positiveMessage.Add ("This group suck! Nice stream!");
		positiveMessage.Add ("You rub the show!");
		positiveMessage.Add ("Marry me!");
		positiveMessage.Add ("You're in my heart forever!");
		positiveMessage.Add ("Not bad!");
		positiveMessage.Add ("So Funny!");
		positiveMessage.Add ("I love you!");
		positiveMessage.Add ("OMFG, this shit rocks!");
		positiveMessage.Add ("Rock on!");

		negativeMessage.Add ("Crappy show!");
		negativeMessage.Add ("You are SO BAD!");
		negativeMessage.Add ("FAIL BIG NOOB!");
		negativeMessage.Add ("So bad dude!");
		negativeMessage.Add ("Dude, go home!");
		negativeMessage.Add ("Are you playing something?");
		negativeMessage.Add ("What Are you trying to do?");
		negativeMessage.Add ("You suck!");
		negativeMessage.Add ("Justin Bieber is better than you!");
		negativeMessage.Add ("Shut the fuck up!");
		negativeMessage.Add ("Fucking stupid bitch");

		name.Add ("Pickles123: ");
		name.Add ("Bobette505: ");
		name.Add ("LifeIsHard342: ");
		name.Add ("Alpe Nismu: ");
		name.Add ("Alva Gingras: ");
		name.Add ("T-Bones92: ");
		name.Add ("GodZilla177: ");
		name.Add ("buster8: ");
		name.Add ("necrophile4life: ");
		name.Add ("Grampa14: ");
		name.Add ("WashMePlz: ");
		name.Add ("7UpepsiSuck: ");
		name.Add ("Crappy9: ");
		name.Add ("SexyKitten42: ");
		name.Add ("YourMomInShorts3: ");
		name.Add ("1337: ");

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
		
		scrollPos = chat.BeginScrollView (new Rect (Screen.width - 30 - 150, 30, 150, 150), scrollPos, GetMessagesHeight(allChatMessage, 150), Vector4.zero);
		foreach(string c in allChatMessage)
		{
			GUILayout.Label(c,GUILayout.MaxWidth(150));
		}
		chat.EndScrollView();
		GUI.Box (new Rect (Screen.width - 30 - 150, 30, 150, 150), "");
		scrollPos.y++;
	}
}
