using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoverEffects : MonoBehaviour {

	public Texture2D standardCursor;
	public Texture2D clickableCursor;
	public string tooltipText;
	private Vector2 hotSpot = Vector2.zero;
	//private GUIText msgBox;	//GUIElements
	private Text msgBox;		//uGUI

	void Start()
	{
		//msgBox = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<GUIText>();	//GUIElements
		msgBox = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Text>();	//uGUI
		msgBox.transform.position = Vector3.zero;
	}

	void OnMouseEnter()
	{
		if (clickableCursor != null)
			Cursor.SetCursor(clickableCursor,hotSpot,CursorMode.Auto);

		msgBox.text = tooltipText;
		//GUIElements -B
		/*
		Vector2 pos;
		pos.x =	Input.mousePosition.x ;
		pos.y =	Input.mousePosition.y + 20; // um Text etwas hoeher anzuzuzeigen.
		msgBox.pixelOffset = pos;
		*/
		//GUIElements -E

		//uGUI -B
		Vector3 pos;
		pos.x =	Input.mousePosition.x ;
		pos.y =	Input.mousePosition.y + 20; // um Text etwas hoeher anzuzuzeigen
		pos.z = 0;
		msgBox.rectTransform.position = pos;
		//uGUI -E
	}

	void OnMouseExit()
	{
		ExitEffect();
	}

	void OnDestroy()
	{
		ExitEffect();
	}

	void ExitEffect()
	{
		if (standardCursor != null)
			Cursor.SetCursor(standardCursor,hotSpot,CursorMode.Auto);

		if (msgBox != null)
			msgBox.text = "";
	}
}
