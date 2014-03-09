using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {

	private static string textToEdit = "";
	public Font myFont; 
	public Texture2D bg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),bg);

		GUI.skin.font = myFont;
		if (GUI.Button(new Rect(Screen.width/33 * 11.7f, ((Screen.height/18)*6.8f), Screen.width/12, Screen.height/18), ""))
		{
			Application.LoadLevel("Menu");			
		}
		GUI.Label(new Rect(10,Screen.height - 70,Screen.width,Screen.height), "<color=black>Path to your sound:</color>");
		textToEdit = GUI.TextField(new Rect(10, Screen.height - 40, 200, 30), textToEdit, 25);
		GlobalVariable.songPath = textToEdit;
	} 
}
