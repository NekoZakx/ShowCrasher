using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private ArrayList objects;
	public int nbTriangle;
	public int nbCymbal;
	public int nbTrumpet;
	public Font myFont;
	private float offsetX = 50.0f;
	private float offsetY = 5.0f;
	public Texture textureTriangle;
	public Texture textureCymbal;
	public Texture textureTrumpet;
	private static bool btriangle;
	private static bool bcymbal;
	private static bool btrumpet;
	public RuntimeAnimatorController CU;
	public RuntimeAnimatorController CUC;
	public RuntimeAnimatorController CUT;
	public RuntimeAnimatorController C;
	public RuntimeAnimatorController CCUT;
	public RuntimeAnimatorController CT;
	public RuntimeAnimatorController T;	


	// Use this for initialization
	void Start () {
		objects = new ArrayList();
		btriangle = false;
		bcymbal = false;
		btrumpet = false;
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
		objects.Add (newObject);
		if (newObject.name.Equals("Triangle"))
		{
			nbTriangle++;
			btriangle = true;
		}
		if (newObject.name.Equals("Cymbal"))
		{
			nbCymbal++;
			bcymbal = true;
		}
		if (newObject.name.Equals("Trumpet"))
		{
			nbTrumpet++;
			btrumpet = true;
		}
		checkcollectables();
	}

	void OnGUI()
	{
		GUI.skin.font = myFont;
		GUI.BeginGroup(new Rect(offsetX, Screen.height-offsetY-40.0f, 505, 30));
		GUI.DrawTexture(new Rect(offsetX, 0, 30, 30), textureCymbal);
		GUI.Label(new Rect(offsetX+35, 0, 45, 30), "" + nbCymbal);
		GUI.DrawTexture (new Rect (offsetX+85, 0, 30, 30), textureTriangle);
		GUI.Label(new Rect(offsetX+120, 0, 45, 30), "" + nbTriangle);
		GUI.DrawTexture (new Rect (offsetX+170, 0, 30, 30), textureTrumpet);
		GUI.Label(new Rect(offsetX+205, 0, 45, 30), "" + nbTrumpet);
		GUI.EndGroup();
	}

	void checkcollectables()
	{
		if (btriangle && btrumpet && bcymbal)
		{
			GetComponent<Animator>().runtimeAnimatorController = CCUT;
		}
		else if (btrumpet && bcymbal)
		{
			GetComponent<Animator>().runtimeAnimatorController = CUC;
		}else if (btrumpet && btriangle)
		{
			GetComponent<Animator>().runtimeAnimatorController = CUT;
		}else if (btriangle && bcymbal)
		{
			GetComponent<Animator>().runtimeAnimatorController = CT;
		}else if (btrumpet)
		{
			GetComponent<Animator>().runtimeAnimatorController = CU;
		}else if (bcymbal)
		{
			GetComponent<Animator>().runtimeAnimatorController = C;
		}else if (btriangle)
		{
			GetComponent<Animator>().runtimeAnimatorController = T;
		}
		else
		{

		}
	}
}
