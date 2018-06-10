using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : HealthController {

	public AudioClip hurtClip;
	public AudioClip deathClip;
	//public GUITexture healthGui; 	//GUIElement
	public Image healthGui;			//uGUI
	private LifePointController lifePointController;
	private float maxHealth;

	//private GUIText messageText;	//GUIElement
	private Text messageText;		//uGUI
	//private Rect guiRect;			//GUIElement
	//private float guiMaxWidth;	//GUIElement
	private AudioSource audioSource;
	void Start () {
		//messageText = GameObject.FindGameObjectWithTag ("Message").
		//	GetComponent<GUIText>();	//GUIElement
		messageText = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
		lifePointController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<LifePointController>();
		audioSource = GetComponent<AudioSource>();
		//guiRect = new Rect (healthGui.pixelInset); //GUIElement
		//guiMaxWidth = guiRect.width;	//GUIElement
		maxHealth = health;
		UpdateView();
	}

	public override void Damaging ()
	{
		audioSource.clip = hurtClip;
		audioSource.Play ();
		UpdateView();
	}

 	public override void Dying ()
	{
		audioSource.clip = deathClip;
		audioSource.Play ();
		UpdateView();

		lifePointController.LifePoints -= 1;

		if(lifePointController.LifePoints > 0)
			Invoke("Restart",1);
		else
			messageText.text = "Game Over";
	}

	void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void UpdateView()
	{
		if(healthGui != null) {
			//guiRect.width = guiMaxWidth * health/maxHealth;	//GUIElement
			//healthGui.pixelInset = guiRect;	//GUIElement
			healthGui.fillAmount = health/maxHealth; //uGUI
		}
	}
}
