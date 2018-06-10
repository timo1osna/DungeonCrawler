using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	public float damageValue = 1;
	public float attackingSpeed = 4;
	public Transform[] waypoints; 
	public float waypointPauseTime = 2;

	private GameObject player;
	private UnityEngine.AI.NavMeshAgent agent;
	private Animator anim;
	private MonsterSonar enemySonar;
	private PlayerHealth playerHealth;
	private MonsterHealth enemyHealth;
	private int currentWaypointIndex;
	private bool readyToHit = true;  
	private int attackBool;
    private int lookBool;

	void Start () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemySonar = GetComponent<MonsterSonar>();
		enemyHealth = GetComponent<MonsterHealth>();
		anim = transform.GetComponent<Animator>();
		attackBool = Animator.StringToHash ("attack");
        lookBool = Animator.StringToHash("look");

	}

	void Update () 
	{

		if (!enemySonar.playerDetected)
		{
			WaypointWalk ();
		}
		//Wenn ich und der Spierl gesund sind, ich nicht geschockt bin und
		//ich angriffbereit bin
		else if (enemyHealth.health > 0  &&
		         	playerHealth.health > 0 &&
					//!enemySonar.obstacleDetected && 
					!enemyHealth.isShocked &&
					readyToHit)	
		{
			agent.speed = attackingSpeed;
			agent.acceleration = 2;
			agent.SetDestination (player.transform.position);
			//Unity 5 -B
			agent.Resume(); //Pfadsuche weiter machen (falls gestoppt wurde)
                            //Unity 5 -E
        }
		else
		{
			//Unity 5 -B
			//agent.Stop (true);
			agent.Stop(); //Pfadsuche stoppen
			agent.velocity = new Vector3(0,0,0); //Sofort anhalten
			//Unity 5 -E
		}
	}

	void WaypointWalk ()
	{
		if(agent.remainingDistance <= agent.stoppingDistance)
		{
			if(currentWaypointIndex == waypoints.Length - 1)
				currentWaypointIndex = 0;
			else
				currentWaypointIndex++;	

			StartCoroutine("WaypointPause",waypointPauseTime);
		}
		agent.SetDestination (waypoints[currentWaypointIndex].position);
	}

	void OnTriggerStay(Collider other)
	{
		if (enemyHealth.health > 0)
		{
			if (other.CompareTag("Player") && playerHealth.health > 0)
			{
				if (readyToHit)
				{
					readyToHit = false;
					//sollte der Spieler in den Enemy laufen bevor dieser vom Enemy entdeckt wurde.
					if(!enemySonar.playerDetected)		
						enemySonar.StopSearching();

					other.gameObject.SendMessage (
						"ApplyDamage",damageValue,SendMessageOptions.DontRequireReceiver);
					StartCoroutine("SetReadyToHit");
				}
			}
		}
	}

	IEnumerator SetReadyToHit()
	{
		anim.SetBool(attackBool,true);
		yield return new WaitForSeconds(0.5F);
		anim.SetBool(attackBool,false);
		yield return new WaitForSeconds(0.5F);
		readyToHit = true;

	}

	IEnumerator WaypointPause(float seconds)
	{
		float oldSpeed = agent.speed;
		agent.speed = 0.0F;
        anim.SetBool(lookBool, true);
		yield return new WaitForSeconds(seconds);
        anim.SetBool(lookBool, false);
		agent.speed = oldSpeed;
	}
}
