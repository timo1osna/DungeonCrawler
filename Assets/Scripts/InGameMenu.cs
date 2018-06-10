using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	private PlayerController playerController;
	private LifePointController lifePointController;
	// Use this for initialization
	void Start () {
		playerController = GameObject.FindGameObjectWithTag("Player").
			GetComponent<PlayerController>();

		lifePointController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<LifePointController>();
	}

	void Update()
	{
		if(lifePointController.LifePoints == 0 || playerController.gameEnded)
		{
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return))
			{
				Application.LoadLevel(0);
			}
		}
	}
}
