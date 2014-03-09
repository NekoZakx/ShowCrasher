using UnityEngine;
using System.Collections;

public class GlobalVariable : MonoBehaviour {

	public static string songPath;
	public static int score;
	public static int nbJump;
	public static int nbWaveComboMax;
	public static bool crowdGetOut = false;
	public static bool endOfGame = false;
	public static int  nbWaveDestroy;

	void Start () 
	{
		nbWaveDestroy = 0;
		score = 0;
		nbWaveComboMax = 0;
		nbJump = 0;
	}
}
