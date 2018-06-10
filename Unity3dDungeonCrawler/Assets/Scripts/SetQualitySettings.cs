using UnityEngine;
using System.Collections;

public class SetQualitySettings : MonoBehaviour {
	
	public void IncreaseQuality()
	{
		//Qualitaetsstufe anheben
		QualitySettings.IncreaseLevel(true);
	}
	
	public void DecreaseQuality()
	{
		//Qualitaetsstufe senken
		QualitySettings.DecreaseLevel(true);
	}

}
