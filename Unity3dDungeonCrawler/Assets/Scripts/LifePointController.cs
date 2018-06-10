using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifePointController : MonoBehaviour {

	//public GUIText lpText;	//GUIElement
	public Text lpText;			//uGUI
	private int lifePoints = 0;
	
	public int LifePoints 
	{
		get 
		{
			return lifePoints; 
		}
		set 
		{ 
			lifePoints = value; 
			if(lifePoints < 0)
				lifePoints = 0;
			UpdateView();
		}
	}

	void Awake()
	{
		LifePoints = PlayerPrefs.GetInt("LPs");		
		LifePoints = LifePoints;
	}

	void UpdateView()
	{	
		lpText.text = lifePoints.ToString();
	}

	void OnDestroy()
	{
		PlayerPrefs.SetInt("LPs",lifePoints);
	}

}
