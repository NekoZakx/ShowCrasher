using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	AudioSource audio;
	WaveSpawn master;
	void Start () 
	{
		audio = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
		master = gameObject.GetComponent<WaveSpawn>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(audio.clip.length);
		if(audio.clip.length < Time.time)
		{
			master.ProduceWave  = false;
		}
	}
}
