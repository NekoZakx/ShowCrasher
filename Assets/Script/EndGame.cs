using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	private AudioSource audio;
	private WaveSpawn master;
	private Animator playerAnimator; 
	public Font myFont;

	void Start () 
	{
		audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
		master = gameObject.GetComponent<WaveSpawn>();
		playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(audio.clip.length < Time.time)
		{
			master.ProduceWave  = false;

			if(!GameObject.FindGameObjectWithTag("Wave"))
			{
				playerAnimator.SetBool("endAnim",true);
				GlobalVariable.endOfGame = true;
			}

		}
	}

	void OnGUI() 
	{
		if(GlobalVariable.endOfGame)
		{
			GUI.skin.font = myFont;
			GUI.skin.label.alignment = TextAnchor.UpperCenter; 
			if (GUI.Button(new Rect(Screen.height/1.8f, Screen.width/2, 200, 40), "Quitter"))
			{
				Application.Quit();			
			}
		}
	}
}
