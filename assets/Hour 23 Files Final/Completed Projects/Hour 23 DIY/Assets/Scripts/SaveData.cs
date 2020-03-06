using UnityEngine;

public class SaveData : MonoBehaviour
{
	string playerName = "";

	void OnGUI()
	{
		playerName = GUI.TextField(new Rect(5, 120, 100, 30), playerName);
		if (GUI.Button(new Rect(5, 180, 50, 50), "Save"))
		{
			PlayerPrefs.SetString("name", playerName);
		}
	}
}
