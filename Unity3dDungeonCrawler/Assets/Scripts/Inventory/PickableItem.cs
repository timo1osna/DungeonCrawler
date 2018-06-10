using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

	public InventoryItem inventoryItem;
	private Inventory inventory;
	private Transform player;

	void Start () {

		player = GameObject.FindGameObjectWithTag("Player").transform;
		inventory = player.GetComponent<Inventory>();

	}
	
	void OnMouseDown() 
	{
		if (inventory.AddItem (inventoryItem)) {				
			if (inventoryItem.picSound != null)
				AudioSource.PlayClipAtPoint(inventoryItem.picSound,player.position);

			Destroy(gameObject);
		}		
	}
}