using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {

	private static string textToEdit = "";
	public Font myFont; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		GUI.skin.font = myFont;
		if (GUI.Button(new Rect(10, 100, 200, 40), "Begin Tour"))
		{
			Application.LoadLevel("Menu");			
		}
		GUI.Label(new Rect(10,0,Screen.width,Screen.height), "Path of your song: ");
		textToEdit = GUI.TextField(new Rect(10, 50, 200, 30), textToEdit, 25);
		GlobalVariable.songPath = textToEdit;
	} 
}
