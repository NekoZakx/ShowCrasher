using UnityEngine;
using System.Collections;

public class crowdAction : MonoBehaviour 
{

	private float vitesse;
	private int   nbWaveDepart;
	private Animator crowdAnimation;
	private bool partirStat;

	void Start () 
	{
		partirStat = false;
		crowdAnimation = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!partirStat)
		{
			rigidbody2D.velocity = new Vector2(vitesse, 0);
		}
		else
		{
			rigidbody2D.velocity = new Vector2(vitesse*2.5f, 0);
		}

		if(transform.position.x < -50)
		{
			Destroy(this.gameObject);
		}

		if(nbWaveDepart < GlobalVariable.nbWaveDestroy)
		{
			partirStat = true;
			crowdAnimation.SetBool("GTFO", true);
		}
	}

	public void setVitesse(int vitesseRecu)
	{
		vitesse = vitesseRecu;
	}

	public void setNbWaveDepart(int nbWaveDepartRecu)
	{
		nbWaveDepart = nbWaveDepartRecu;
	}
}
