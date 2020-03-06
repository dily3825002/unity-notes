using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip1;
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			if (audioSource.isPlaying == true)
				audioSource.Stop();
			else
				audioSource.Play();
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			audioSource.loop = !audioSource.loop; //toggles lopping
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			audioSource.Stop();
			audioSource.clip = clip1;
			audioSource.Play();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			audioSource.Stop();
			audioSource.clip = clip2;
			audioSource.Play();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			audioSource.Stop();
			audioSource.clip = clip3;
			audioSource.Play();
		}
	}
}
