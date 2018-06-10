using UnityEngine;
using System.Collections;

public class AnimateDoor : MonoBehaviour {

	public AudioClip lockedDoorMonologueClip;
	public bool isLocked = true;
	public InventoryItem keyInventoryItem;

	private Animator anim;
	private int switchTrigger;
	//private DoorMovingState doorMovingState;
	private GameObject player;
	private Inventory inventory;


	void Start () {
		switchTrigger = Animator.StringToHash ("Switch");
		anim = transform.parent.GetComponent<Animator>();
		//doorMovingState = transform.parent.GetComponent<DoorMovingState>();

		player = GameObject.FindGameObjectWithTag("Player");
		inventory = player.GetComponent<Inventory>();

	}

	void OnMouseDown() {

		if (isLocked)
		{
			//if(inventory.RemoveItem("Key"))
			if(inventory.RemoveItem(keyInventoryItem))
			{
				isLocked = false;
			}
		}

		if (!isLocked)
		{
			//if (!doorMovingState.isMoving)
			//{
			anim.SetTrigger (switchTrigger);

				//AudioSource.PlayClipAtPoint(doorClip,transform.position);
			//}
		}
		else
		{
			player.GetComponent<AudioSource>().clip = lockedDoorMonologueClip;
			player.GetComponent<AudioSource>().Play ();
		}

	}

}
