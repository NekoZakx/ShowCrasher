using UnityEngine;
using System.Collections;

public class AngleCamera : MonoBehaviour {

	public Texture2D textureCadre;
	private Vector2 scale = new Vector2(1,1);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(10, Screen.height-100, 100, 100), textureCadre);
		scale.y = -1;
		GUI.DrawTexture (new Rect (10, 100, 100, 100*scale.y), textureCadre);
		scale.x = -1;
		GUI.DrawTexture (new Rect (Screen.width-10, 100, 100*scale.x, 100*scale.y), textureCadre);
		scale.y = 1;
		GUI.DrawTexture (new Rect (Screen.width-10, Screen.height-100, 100*scale.x, 100*scale.y), textureCadre);
	}
}
