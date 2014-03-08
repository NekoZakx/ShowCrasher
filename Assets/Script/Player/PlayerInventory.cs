using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private ArrayList objects;

	// Use this for initialization
	void Start () {
		objects = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddToInventory(ObjectParam newObject)
	{
		Debug.Log(newObject.name);
		objects.Add(newObject);
	}
}
