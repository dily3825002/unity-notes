using UnityEngine;
using UnityEngine.Playables;

public class InputControl : MonoBehaviour
{
	PlayableDirector director;

	void Start()
	{
		director = GetComponent<PlayableDirector>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			if (director.state == PlayState.Paused)
				director.Play();
			else
				director.Stop();
		}
	}
}
