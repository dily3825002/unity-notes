using UnityEngine;

public class AccelerometerScript : MonoBehaviour
{
	void Update ()
	{
		float x = Input.acceleration.x * Time.deltaTime;
		float z = -Input.acceleration.z * Time.deltaTime;
		transform.Translate(x, 0f, z);
	}
}
