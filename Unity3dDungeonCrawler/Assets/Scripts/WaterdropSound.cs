using UnityEngine;
using System.Collections;

public class WaterdropSound : MonoBehaviour {

	public AudioClip clip;
	private ParticleSystem ps;
	private AudioSource audioSource;
	void Start()
	{
		ps = GetComponent<ParticleSystem>();
		audioSource = GetComponent<AudioSource>();
	}
	void OnParticleCollision(GameObject other) {
		//Unity 5 -B
		//ParticleSystem.CollisionEvent[] collisionEvents = new ParticleSystem.CollisionEvent[5];
		ParticleCollisionEvent [] collisionEvents = new ParticleCollisionEvent[5];
		//Unity 5 -E
		int quantityCollisionEvents = 
			ps.GetCollisionEvents(other, collisionEvents);
		int i = 0;
		while (i < quantityCollisionEvents) {
			//Vector3 pos = collisionEvents[i].intersection;
			//AudioSource.PlayClipAtPoint(clip,pos,0.3F);
			audioSource.Play();
			i++;
		}
	}
}
