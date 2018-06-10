using UnityEditor;
using UnityEngine;
using System.Collections;

public class CreateInventoryItem
{
	[MenuItem("Assets/Create/Inventory Item")]
	static void CreateAsset()
	{
		if(!AssetDatabase.IsValidFolder("Assets/Inventory Items"))
			AssetDatabase.CreateFolder("Assets","Inventory Items");

		ScriptableObject asset = ScriptableObject.CreateInstance(typeof(InventoryItem));	

		AssetDatabase.CreateAsset(asset, "Assets/Inventory Items/" +
		                          "New InventoryItem " + System.Guid.NewGuid () + ".asset");
		                        //  typeof(InventoryItem).ToString() + System.Guid.NewGuid () + ".asset");
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh ();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
}
