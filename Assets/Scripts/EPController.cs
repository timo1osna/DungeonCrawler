using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EPController : MonoBehaviour {

	//public GUIText epText;	//GUIElement
	public Text epText;			//uGUI
	private int eps = 0;
	void Start()
	{	
		UpdateView();
	}

	public void AddPoints(int points)
	{
		eps += points;
		UpdateView();
	}

	void UpdateView()
	{
		epText.text = "EP: " + eps.ToString ();
	}
}
