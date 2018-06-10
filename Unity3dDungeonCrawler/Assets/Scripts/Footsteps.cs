using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {
	public AudioClip audioClip;
	public float stepLength = 0.4F;
	public float volume = 0.7F;
	private CharacterController controller;
	private float delay = 0;
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		if (controller.velocity.sqrMagnitude > 0.2F && controller.isGrounded) 
		{
			if (delay >=stepLength)
			{
				AudioSource.PlayClipAtPoint(audioClip,transform.position,volume);
				delay = 0;
			}
		}
		delay += Time.deltaTime;
	}
}
