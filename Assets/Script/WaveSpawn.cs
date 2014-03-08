using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

public class WaveSpawn : MonoBehaviour {

	public GameObject wave1;
	public GameObject wave2;
	public GameObject wave3;
	public GameObject item;
	private ArrayList waveList;
	private ArrayList itmList;
	private float timer = 0.0f;
	private float timeSpawn = 1.0f;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
	private int size = 1;
	private GameObject waveSpawn;
	private GameObject itemSpawn;
	private Vector2 wavePosition;
	private Vector2 itmPosition;
	private float[] itmHeight;

	// Use this for initialization
	void Awake()
	{
		itmHeight = new float[3];
		itmHeight [0] = 1.0f;
		itmHeight [1] = 4.0f;
		itmHeight [2] = 8.0f;
		
		waveList = new ArrayList();
		itmList = new ArrayList();
	}
	void Start () {
		WaveMaintenance ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{

		timer += Time.deltaTime;
		Debug.Log ("FixedUpdate");
		if(timer >= timeSpawn)
		{
			timeSpawn = RollDice(5);
			size = RollDice(3);
			switch(size)
			{
			case 1:
				wavePosition = new Vector2(3.0f,-0.9f);
				itmPosition = new Vector2(3.0f,itmHeight[0]);
				waveSpawn = (GameObject)Instantiate(wave1, wavePosition , Quaternion.identity);
				break;
			case 2:
				wavePosition = new Vector2(3.0f,0.1f);
				itmPosition = new Vector2(3.0f,itmHeight[1]);
				waveSpawn = (GameObject)Instantiate(wave2, wavePosition, Quaternion.identity);
				break;
			case 3:
				wavePosition = new Vector2(3.0f,1.5f);
				itmPosition = new Vector2(3.0f,itmHeight[2]);
				waveSpawn = (GameObject)Instantiate(wave3, wavePosition, Quaternion.identity);
				break;
			default:
				break;
			}
			itemSpawn = (GameObject)Instantiate(item, itmPosition , Quaternion.identity);
			waveList.Add (waveSpawn);
			itmList.Add (itemSpawn);
			timer = 0.0f;
		
			Debug.Log ("TimeSpawn : " + timeSpawn);
			Debug.Log ("Size : " + size);
		}

	}
	void WaveMaintenance()
	{
		for(int i = waveList.Count-1;i>=0;i--)
		{
			GameObject waveDestroy = (GameObject)waveList[i];
			Destroy(waveDestroy.gameObject);
			waveList.RemoveAt(i);        
		}
		for(int i = itmList.Count-1;i>=0;i--)
		{
			GameObject itmDestroy = (GameObject)itmList[i];
			Destroy(itmDestroy.gameObject);
			itmList.RemoveAt(i);        
		}
	}
	public static byte RollDice(byte numberSides)
	{
		if (numberSides <= 0)
			throw new ArgumentOutOfRangeException("numberSides");
		
		// Create a byte array to hold the random value. 
		byte[] randomNumber = new byte[1];

		do
		{
			// Fill the array with a random value.
			rngCsp.GetBytes(randomNumber);
		}

		while (!IsFairRoll(randomNumber[0], numberSides));
		// Return the random number mod the number 
		// of sides.  The possible values are zero- 
		// based, so we add one. 
		return (byte)((randomNumber[0] % numberSides) + 1);
	}
	
	private static bool IsFairRoll(byte roll, byte numSides)
	{
		// There are MaxValue / numSides full sets of numbers that can come up 
		// in a single byte.  For instance, if we have a 6 sided die, there are 
		// 42 full sets of 1-6 that come up.  The 43rd set is incomplete. 
		int fullSetsOfValues = Byte.MaxValue / numSides;
		
		// If the roll is within this range of fair values, then we let it continue. 
		// In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use 
		// < rather than <= since the = portion allows through an extra 0 value). 
		// 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair 
		// to use. 
		return roll < numSides * fullSetsOfValues;
	}
}
