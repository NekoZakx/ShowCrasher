using UnityEngine;
using System.Collections;


public class Stats : MonoBehaviour {

	public bool endOfGame = false;
	public Font myFont;

	private int totalViewers;
	private int maximumCombo;
	private int nbInstruments;

	/*
	 * 
	 * 
	 * 
	 * 
	 * 
	 * METTRE LES VALEURS AUX VARIABLES!
	 * 
	 * 
	 * 
	 * 
	 * 
	 */

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(endOfGame)
		{
			GUI.skin.font = myFont;
			GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");
			GUI.skin.label.alignment = TextAnchor.UpperCenter; 
			GUI.Label(new Rect(0,0, Screen.width, Screen.height), "Your Statistiques:");
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.Label(new Rect(0,0, Screen.width, Screen.height), "\nTotalViewers: " + totalViewers + "\nMaximum Combo: " + maximumCombo + "\nNumbers of instrument: " + nbInstruments);
		}
	}
}
