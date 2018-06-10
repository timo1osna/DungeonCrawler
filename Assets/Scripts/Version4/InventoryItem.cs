using UnityEngine;
using System.Collections;

namespace Version4 { 
	public class InventoryItem : MonoBehaviour {

		public string itemName ="";
		//public Texture2D texture;	//GUIElement
		public Sprite texture;		//uGUI
		public AudioClip picSound;
		private Inventory inventory;
		private Transform player;
		void Start () {
			player = GameObject.FindGameObjectWithTag("Player").transform;
			inventory = GameObject.FindGameObjectWithTag("Inventory").
				GetComponent<Inventory>();
		}
		
		void OnMouseDown() 
		{
			if (inventory.AddItem(itemName,texture))
			{
				if (picSound != null)
					AudioSource.PlayClipAtPoint(picSound,player.position);
				Destroy(gameObject);
			}
		}
	}
}