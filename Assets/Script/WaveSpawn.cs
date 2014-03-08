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
	//private ArrayList waveList;
	//private ArrayList itmList;
	private float timer = 0.0f;
	private float timeSpawn = 0.5f;
	private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
	private int size = 1;
	private GameObject waveSpawn;
	private GameObject itemSpawn;
	private Vector2 wavePosition;
	private float[] itmHeight;
	private float waveHeight;
	private float CurrentVelocitySpawn;
	private float bouncePower;
	private Vector2 initWavePosition;
	private Vector2 initItemPosition;
	// Use this for initialization
	void Awake()
	{
		itmHeight = new float[3];
		itmHeight [0] = 8.0f;
		itmHeight [1] = 12.0f;
		itmHeight [2] = 16.0f;
		waveHeight = -0.9f;
		initWavePosition = transform.position; 
		initItemPosition.x = transform.position.x+2; 
		//waveList = new ArrayList();
		//itmList = new ArrayList();
	}
	void Start () {
		//ClearGame ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{
		initWavePosition.y = waveHeight;
		CurrentVelocitySpawn = -15f;
		timer += Time.deltaTime;
		Debug.Log ("FixedUpdate");
		if(timer >= timeSpawn)
		{

			switch(size)
			{
			case 1:
				initItemPosition.y = itmHeight [0];
				waveSpawn = (GameObject)Instantiate(wave1, initWavePosition , Quaternion.identity);
				bouncePower = 8;
				break;
			case 2:
				initItemPosition.y = itmHeight [1];
				initWavePosition.y+=1.0f;
				waveSpawn = (GameObject)Instantiate(wave2, initWavePosition, Quaternion.identity);
				bouncePower = 13;
				break;
			case 3:
				initItemPosition.y = itmHeight [2];
				initWavePosition.y+=2.1f;
				waveSpawn = (GameObject)Instantiate(wave3, initWavePosition, Quaternion.identity);
				bouncePower = 18;
				break;
			default:
				break;
			}
			size = RollDice(3);
			/*if (timeSpawn!=2)
			{
				while(size==3)
				{
					size = RollDice(3);
				}
			}*/
			itemSpawn = (GameObject)Instantiate(item, initItemPosition , Quaternion.identity);
			itemSpawn.GetComponent<Collectable>().SetVelocity(CurrentVelocitySpawn);
			waveSpawn.GetComponent<WaveScript>().SetVelocity(CurrentVelocitySpawn);
			waveSpawn.GetComponent<WaveScript>().BouncePower = bouncePower;
			//waveList.Add (waveSpawn);
			//itmList.Add (itemSpawn);
			timer = 0.0f;
		
			Debug.Log ("TimeSpawn : " + timeSpawn);
			Debug.Log ("Size : " + size);
		}
	}

	/*void ClearGame()
	{
  		for(int i = waveList.Count-1;i>=0;i--)
		{
			GameObject waveDestroy = (GameObject)waveList[i];
			Destroy(waveDestroy.gameObject);
			//waveList.RemoveAt(i);        
		}
		for(int i = itmList.Count-1;i>=0;i--)
		{
			GameObject itmDestroy = (GameObject)itmList[i];
			Destroy(itmDestroy.gameObject);
			//itmList.RemoveAt(i);        
		}
	}*/
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
