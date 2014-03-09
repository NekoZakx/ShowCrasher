using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicLoader : MonoBehaviour {

	public AudioSource GameMusic;
	private AudioSource crowd;
	private float timeBeforeLoadMusic;
	private float timeLeft = 0f;

	// Use this for initialization
	void Start () {
		GameMusic = GetComponent<AudioSource>();
		//Debug.LogWarning("SIZE OF MAIN MUSIC: " + GameMusic.clip.length);
		//GameMusic.clip = Resources.Load<AudioClip>("Queen - We Are The Champion");

		crowd = GameObject.FindGameObjectWithTag("CrowdSound").GetComponent<AudioSource>();
		crowd.clip = Resources.Load<AudioClip>("cheerring");
		timeBeforeLoadMusic = crowd.clip.length;
		crowd.Play();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft += Time.deltaTime;

		if(timeLeft >= timeBeforeLoadMusic/2.1 && !crowd.loop)
		{
			crowd.clip = Resources.Load<AudioClip>("CrowdHappy");
			crowd.loop = true;
			crowd.Play();
			GameMusic.Play();
			GameObject.FindGameObjectWithTag("Respawn").GetComponent<WaveSpawn>().ProduceWave = true;
		}
	}
}
