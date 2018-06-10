using UnityEngine;
using System.Collections;

public class DummyRemove : MonoBehaviour {

	public InventoryItem itemProperties;
	private Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
	}
	
	void OnGUI()
	{
		if (GUILayout.Button("Remove " + itemProperties.itemName))
		{
			Debug.Log (inventory.RemoveItem(itemProperties));
		}
	}
}
