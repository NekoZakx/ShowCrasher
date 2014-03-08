using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	private int score;
	public Font myFont;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (score > 0) 
		{
			score -= 30;
		}*/
	}

	public void inscreaseScore(int newScore)
	{
		score += newScore;
	}

	public void decreaseScore(int newScore)
	{
		if (score - newScore > 0) 
		{
			score -= newScore;
		}
	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
		GUI.Label(new Rect(0,0,Screen.width,Screen.height), "Subscribers: " + score);
	}
}
