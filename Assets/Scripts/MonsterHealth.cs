using UnityEngine;
using System.Collections;

public class MonsterHealth : HealthController {
	public bool isShocked = false;
	public float shockedTime = 0.5F;
	public int eps = 1;
	private MonsterSonar enemySonar;
	private EPController epController;
	private Animator anim;
    private AnimateDoor animateDoor;
	private int hitTrigger;
	private int dieBool;
	//private AudioSource audioSource;
	void Start()
	{
		enemySonar = GetComponent<MonsterSonar>();
		epController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EPController>();
		hitTrigger = Animator.StringToHash ("hit");
		dieBool = Animator.StringToHash ("die");
		anim = transform.GetComponent<Animator>();
		animateDoor = GameObject.FindGameObjectWithTag("endGate").GetComponent<AnimateDoor>();
		//audioSource = GetComponent<AudioSource>();
	}

	public override void Damaging ()
	{	
		anim.SetTrigger(hitTrigger);
		//audioSource.Play ();
		isShocked = true;

		if(!enemySonar.playerDetected)		
			enemySonar.StopSearching();

		Invoke("ResetShocked",shockedTime);
	}

	public override void Dying ()
	{
        
        animateDoor.isLocked = false;
        anim.SetBool(dieBool, true);
        anim.SetTrigger(hitTrigger);
        //audioSource.Play();
        isShocked = true;
        Invoke("DestroyMe", 1);
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
