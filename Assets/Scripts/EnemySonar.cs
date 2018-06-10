using UnityEngine;
using System.Collections;

public class EnemySonar : MonoBehaviour {
	public float fieldOfView = 120;
	//public bool obstacleDetected = false;
	public bool playerDetected = false;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating("Searching",0.5F,0.5F);
	}

	void Searching()
	{
		Vector3 direction = player.transform.position - transform.position;
		Ray ray = new Ray(transform.position,direction.normalized);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit,5))
		{
			if(hit.collider.gameObject == player)
			{
				Vector3 dir = hit.transform.position - transform.position;
				float angle = Vector3.Angle(dir, transform.forward);					

				if(angle < fieldOfView * 0.5f)					
					StopSearching ();

			}
		}	
	}

	public void StopSearching ()
	{
		playerDetected = true;
		CancelInvoke ("Searching");			
	}
	/*
	void OnTriggerEnter(Collider other) 
	{	
		if (other.gameObject.CompareTag("Door"))
		{
			obstacleDetected = true;			
		}
	}

	void OnTriggerExit(Collider other) 
	{	
		if (other.gameObject.CompareTag("Door"))
		{
			obstacleDetected = false;			
		}
	}
	*/
}
