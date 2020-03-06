using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
	void Start()
	{
		DontDestroyOnLoad(this);
	}

	void OnMouseDown()
	{
		SceneManager.LoadScene(1); 
	}
}
