using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicLoader : MonoBehaviour {

	AudioSource src;

	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource>();
		src.clip = Resources.Load<AudioClip>("Queen - We Are The Champion");
		src.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
