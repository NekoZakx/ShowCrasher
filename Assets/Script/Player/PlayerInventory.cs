using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private ArrayList objects;
	public int nbTriangle;
	public int nbCymbal;
	public int nbTrumpet;

	// Use this for initialization
	void Start () {
		objects = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {

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
}
