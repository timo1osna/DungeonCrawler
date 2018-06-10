using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

	//public GameObject projectile;
	public InventoryItem projectileInventoryItem;

	private PlayerHealth playerHealth;
	private Inventory inventory;
	//private GUIText messageText;	//GUIElement
	private Text messageText;		//uGUI
	private string info  = "Zum Angreifen brauchst Du etwas zum Werfen";
	private bool messageShown =false;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		playerHealth = transform.parent.GetComponent<PlayerHealth>();
		inventory = transform.parent.GetComponent<Inventory>();	

		//messageText = GameObject.FindGameObjectWithTag ("Message").
		//	GetComponent<GUIText>();	//GUIElement
		messageText = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.health > 0)
		{
			if (Input.GetButtonDown ("Fire2"))
			{
				if (inventory.RemoveItem(projectileInventoryItem))
			   		Shoot();
				else if (!messageShown)
					StartCoroutine(ShowInfoText());
			}
		}
	}

	void Shoot()
	{
		//Instantiate(projectile,transform.position,transform.rotation);
		Instantiate(projectileInventoryItem.prefab,transform.position,transform.rotation);
		audioSource.Play ();
	}

	IEnumerator ShowInfoText()
	{
		messageText.text = info;
		messageShown = true;
		yield return new WaitForSeconds(2);
		messageText.text = "";
	}
}
