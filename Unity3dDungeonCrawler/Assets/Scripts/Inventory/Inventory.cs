using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public Image[] guiItemImages;
	private Dictionary<InventoryItem,int> items = new Dictionary<InventoryItem,int>();

	void Start()
	{
		UpdateView();
	}

	public bool AddItem(InventoryItem ip)
	{
		if (!items.ContainsKey(ip))
		{
			if (items.Count < guiItemImages.Length)
				items.Add(ip,1);
			else
				return false;
		}
		else
		{
			items[ip]++;
		}
		UpdateView();
		return true;
	}

	public bool RemoveItem(InventoryItem ip)
	{
		if (items.ContainsKey(ip))
		{
			if (items[ip] > 0)
			{
				items[ip] --;

				if (items[ip] <= 0)
				{
					items.Remove(ip);
				}
				UpdateView();
				return true;
			}
		}
		return false;
	}

	void UpdateView()
	{
		int guiCount = guiItemImages.Length;

		for(int i = 0; i< guiCount; i++)
		{
			guiItemImages[i].enabled = false;
			guiItemImages[i].GetComponentInChildren<Text>().text = "";
		}

		int index = 0;
		foreach (KeyValuePair<InventoryItem,int> current in items)
		{
			guiItemImages[index].enabled = true;
			guiItemImages[index].sprite = current.Key.sprite;
			guiItemImages[index].GetComponentInChildren<Text>().text = current.Value.ToString ();
			index++;
		}
	}
}
