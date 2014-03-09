using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundBlast : MonoBehaviour {

	AudioSource src;
	public bool isBlasting;
	public bool isLittleBlasting;
	float timeToLost = 0.75f;
	float timeToGet = 0.25f;
	float currentTimeGet = 0f;
	float currentTimeLost = 0f;
	float currentTimeRecover = 0f;

	void Start()
	{
		src = GetComponent<AudioSource>();
	}

	public void Blast()
	{
		isBlasting = true;
	}

	void Update()
	{
		if(isBlasting)
		{
			currentTimeLost += Time.deltaTime;

			if(currentTimeLost >= timeToLost)
			{
				currentTimeGet += Time.deltaTime;
				if(currentTimeGet >= timeToGet)
				{
					isBlasting = false;
					currentTimeGet = 0f;
					currentTimeLost = 0f;
					currentTimeRecover = 0f;
				}else
				{
					src.pitch = (1.75f/timeToGet) * currentTimeGet;
				}
			}else
			{
				src.pitch = (0.75f/timeToLost) * (timeToLost - currentTimeLost);
			}
		}else if(isLittleBlasting)
		{
			currentTimeLost += Time.deltaTime;
			
			if(currentTimeLost >= (timeToLost/2))
			{
				currentTimeGet += Time.deltaTime;
				if(currentTimeGet >= (timeToGet/2))
				{
					isLittleBlasting = false;
					currentTimeGet = 0f;
					currentTimeLost = 0f;
					currentTimeRecover = 0f;
				}else
				{
					src.pitch = (1.1f/(timeToGet/4)) * currentTimeGet;
				}
			}else
			{
				src.pitch = (0.90f/(timeToLost/4)) * ((timeToLost/2) - currentTimeLost);
			}
		}else
		{
			if(src.pitch != 1f)
			{
				//currentTimeRecover += Time.deltaTime;
				src.pitch = 1f;
			}
		}
	}
}
