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

		if (Input.GetButtonDown("Fire1")) 
		{
			if((Input.mousePosition.x >= 0 && Input.mousePosition.y >= 500) && (Input.mousePosition.x <= 100 && Input.mousePosition.y <= 600))
			{
				Application.LoadLevel("Menu");
			}
		}
	
	}

	void OnGUI() 
	{
		GUI.skin.font = myFont;
		GUI.Label(new Rect(0,0,Screen.width,Screen.height), "Path of your song: ");
		textToEdit = GUI.TextField(new Rect(10, 200, 200, 30), textToEdit, 25);
		GlobalVariable.songPath = textToEdit;
	} 
}
