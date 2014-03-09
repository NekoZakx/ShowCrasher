using UnityEngine;
using System.Collections;


public class Stats : MonoBehaviour {

	public Font myFont;
	private int totalInventaire;

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
		if(GlobalVariable.endOfGame)
		{ 
			totalInventaire = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().getTotalInventaire();
			GUI.skin.font = myFont;
			GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");
			GUI.skin.label.alignment = TextAnchor.UpperCenter; 
			GUI.Label(new Rect(0,0, Screen.width, Screen.height), "Your Statistiques:");
			GUI.skin.label.alignment = TextAnchor.UpperCenter;
			GUI.Label(new Rect(0,0, Screen.width, Screen.height), "\nTotalViewers: " + GlobalVariable.score + "\nMaximum Combo: " + GlobalVariable.nbWaveComboMax + "\nNumbers of instrument: " + totalInventaire + "\nNumbers of jumps: " + GlobalVariable.nbJump);
		}
	}
}
