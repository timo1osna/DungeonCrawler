using UnityEngine;
using System.Collections;

public class StoneBehaviour : MonoBehaviour 
{
	public LayerMask acceptableLayers;
	public GameObject destroyedGo;
	public float damage = 1;
	public float speed = 10; 

	/*
	void Update()
	{
		transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);
	}
	*/

	void FixedUpdate()
	{
		transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);
	}

	void OnTriggerEnter(Collider other) 
	{	
		//Debug.Log(other.tag);
		//Wandelt per bitweiser Verschiebung einen Integer in eine Bitzahl um. 
		//Debug.Log(1 << other.gameObject.layer);
		//Das Ergebnis des bitweisen Vergleichs (&), zwischen Layer und Maske, wird mit dem Layer als Bitzahl verglichen.
		//if ((acceptableLayers.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
		if ((acceptableLayers.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
		{
			if (other.gameObject.CompareTag("Enemy"))
			{
				other.gameObject.SendMessage (
					"ApplyDamage",damage,SendMessageOptions.DontRequireReceiver);						
			}		
			Destroy(gameObject);
			Destroy(Instantiate(destroyedGo,transform.position, Quaternion.identity),1);
		}
	}

}
