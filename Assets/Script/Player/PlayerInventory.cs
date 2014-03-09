using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private ArrayList objects;
	public int nbTriangle;
	public int nbCymbal;
	public int nbTrumpet;
	public Font myFont;
	public float offsetX = 10.0f;
	public float offsetY = 5.0f;
	public Texture textureTriangle;
	public Texture textureCymbal;
	public Texture textureTrumpet;

	// Use this for initialization
	void Start () {
		objects = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public int getTotalInventaire()
	{
		return (nbTriangle+nbCymbal+nbTrumpet);
	}

	public void AddToInventory(ObjectParam newObject)
	{
		int ctrt = 0;
		int ctrc = 0;
		int ctrp = 0;

		objects.Add (newObject);

		for(int i=0; i<objects.Count; i++)
		{
			if (newObject.name.Equals("Triangle"))
				ctrt++;
		}

		for(int i=0; i<objects.Count; i++)
		{
			if (newObject.name.Equals("Cymbal"))
				ctrc++;
		}

		for(int i=0; i<objects.Count; i++)
		{
			if (newObject.name.Equals("Trumpet"))
				ctrp++;
		}
		nbTriangle = ctrt;
		nbCymbal = ctrc;
		nbTrumpet = ctrp;
	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
		GUI.BeginGroup(new Rect(offsetX, Screen.height-offsetY-30.0f, 505, 30));
		GUI.DrawTexture(new Rect(0, 0, 30, 30), textureCymbal);
		GUI.Label(new Rect(35, 0, 45, 30), "" + nbCymbal);
		GUI.DrawTexture (new Rect (85, 0, 30, 30), textureTriangle);
		GUI.Label(new Rect(120, 0, 45, 30), "" + nbTriangle);
		GUI.DrawTexture (new Rect (170, 0, 30, 30), textureTrumpet);
		GUI.Label(new Rect(205, 0, 45, 30), "" + nbTrumpet);
		GUI.EndGroup();
	}
}
