using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	AudioSource audio;
	WaveSpawn master;
	Animator playerAnimator; 

	void Start () 
	{
		audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
		master = gameObject.GetComponent<WaveSpawn>();
		playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(audio.clip.length);
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
}
