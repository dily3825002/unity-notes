using UnityEngine;

public class LoadData : MonoBehaviour
{
	string playerName = "";

	void Start()
	{
		playerName = PlayerPrefs.GetString("name");
	}

	void OnGUI()
	{
		GUI.Label(new Rect(5, 220, 50, 30), playerName);
	}
}
