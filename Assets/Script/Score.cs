using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	private int score;
	public float timer = 6.0f;
	public Font myFont;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (score - 30 > 0 && timer <= 0) 
		{
			score -= 30;
			timer = 6.0f;
		} 
		else if (score - 30 < 0) 
		{
			score = 0;
		}
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
