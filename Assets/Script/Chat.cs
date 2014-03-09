using UnityEngine;
using System.Collections;

public class Chat : MonoBehaviour {

	ArrayList allChatMessage;
	ArrayList positiveMessage;
	ArrayList negativeMessage;
	ArrayList name;

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

		name.Add ("BobTheBuilder123");
		name.Add ("Craftman009987");
		name.Add ("Bond007");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
