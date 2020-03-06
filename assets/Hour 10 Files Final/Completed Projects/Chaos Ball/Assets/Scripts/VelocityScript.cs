using UnityEngine;

public class VelocityScript : MonoBehaviour
{
	public float startSpeed = 50f;

	void Start ()
	{
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity = new Vector3 (startSpeed, 0, startSpeed);
	}
}
