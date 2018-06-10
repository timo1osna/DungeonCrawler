using UnityEngine;
using System.Collections;

public class EnemyHealth : HealthController {
	public bool isShocked = false;
	public float shockedTime = 0.5F;
	public int eps = 1;
	private EnemySonar enemySonar;
	private EPController epController;
	private Animator anim;
	private int hitTrigger;
	private int dieBool;
	private AudioSource audioSource;
	void Start()
	{
		enemySonar = GetComponent<EnemySonar>();
		epController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<EPController>();
		hitTrigger = Animator.StringToHash ("Hit");
		dieBool = Animator.StringToHash ("Die");
		anim = transform.GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	public override void Damaging ()
	{	
		anim.SetTrigger(hitTrigger);
		audioSource.Play ();
		isShocked = true;

		if(!enemySonar.playerDetected)		
			enemySonar.StopSearching();

		Invoke("ResetShocked",shockedTime);
	}

	public override void Dying ()
	{
		anim.SetBool(dieBool,true);
		anim.SetTrigger(hitTrigger);
		audioSource.Play ();
		isShocked = true;	
		Invoke ("DestroyMe",1);
	}

	void ResetShocked()
	{
		isShocked = false;
	}

	void DestroyMe()
	{
		Destroy(gameObject);
		epController.AddPoints (eps);
	}

}
