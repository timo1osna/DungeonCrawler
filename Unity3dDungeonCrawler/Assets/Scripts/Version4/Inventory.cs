using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Version4 { 
	public class Inventory : MonoBehaviour {


		//public GUITexture[] guiItemTextures; 	//GUIElement
		//public GUIText[] guiItemQuantity;		//GUIElement
		public Image[] guiItemTextures; 		//uGUI
		public Text[] guiItemQuantity;			//uGUI
		private Dictionary<string,ItemProperties> items = new Dictionary<string, ItemProperties>();

		void Start()
		{
			UpdateView();
		}

		//public bool AddItem(string itemName, Texture2D texture)	//GUIElement
		public bool AddItem(string itemName, Sprite texture)		//uGUI
		{
			if(!items.ContainsKey(itemName))
			{
			
				if (items.Count < guiItemTextures.Length)
				{
					ItemProperties ip = new ItemProperties();
					ip.texture = texture;
					ip.quantity = 1;			
					items.Add(itemName, ip);
					UpdateView();
					return true;
				}
				else					
				{
					return false;
				}
			}
			else
			{
				items[itemName].quantity += 1;
				UpdateView();
				return true;
			}
		}

		public bool RemoveItem(string itemName)
		{
			if (items.ContainsKey(itemName))
			{
				if(items[itemName].quantity == 1)
					items.Remove(itemName);
				else
					items[itemName].quantity -= 1;

				UpdateView();
				return true;
			}
			else
				return false;
		}

		void UpdateView()
		{
			int index = 0;
			int guiCount = guiItemTextures.Length;

			for(int i = 0; i< guiCount; i++)
			{
				//guiItemTextures[i].texture =  null;	//GUIElement
				guiItemTextures[i].enabled = false;		//uGUI
				guiItemQuantity[i].text = "";
			}

			foreach(KeyValuePair<string,ItemProperties> current in items)
			{
				//guiItemTextures[index].texture = current.Value.texture;	//GUIElement
				guiItemTextures[index].sprite = current.Value.texture;		//uGUI
				guiItemTextures[index].enabled = true;
				guiItemQuantity[index].text = current.Value.quantity.ToString();
				index++;
			}
		}
	}
}
