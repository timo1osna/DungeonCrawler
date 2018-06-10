using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	//private GUIText messageText; 	//GUIElements
	private Text messageText;		//uGUI
	//private Rect rect;			//OnGUI/GUIElements

	void Start () {

		//messageText = GameObject.FindGameObjectWithTag("Message").guiText;	//GUIElements

		messageText = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();	//uGUI
		messageText.text = "<size=20>Willkommen Fremder!</size>\n\n" +
				"Du wurdest in ein Kellergewölbe verbannt.\n" + 
				"Monster und Rätsel warten dort auf Dich.";

		//rect = new Rect(50,50,200,30);	//OnGUI/GUIElements
	}

	//OnGUI/GUIElements -B
	/*
	void OnGUI()
	{

		rect.y = 50;
		if (GUI.Button(rect,"Start"))
		{
			StartGame();
		}

		rect.y += 50;
		if (GUI.Button(rect,"Steuerung und Info"))
		{
			ShowInfo();
		}

		rect.y += 50;
		if (GUI.Button(rect,"Beenden"))
		{
			CloseGame();
		}	

	}
	*/
	//OnGUI/GUIElements -E

	public void StartGame()
	{
		messageText.text = "";
		PlayerPrefs.SetInt("LPs",3); //Startwert		
		Application.LoadLevel(1);
	}

	public void ShowInfo()
	{

		messageText.text = "Deine Steuerung:\n\n" +
				"A/D: Links/Rechts gehen\n" +
				"W/S: Vorwärts/Rückwärts gehen\n" +
				"Q/E: Links/Rechts drehen\n" +
				"Linke Maustaste: Gegenstände aufnehmen\n" +
				"Rechte Maustaste/Leertaste: Angreifen";
	}

	public void CloseGame()
	{		
			Application.Quit();
	}

}
