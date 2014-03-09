using UnityEngine;
using System.Collections;

public class GlobalVariable : MonoBehaviour {

	public static string songPath;
	public static int nbJump;
	public static int nbWaveComboMax;
	public static bool crowdGetOut = false;

	void Start () 
	{
		nbWaveComboMax = 0;
		nbJump = 0;
	}
}
