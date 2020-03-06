using UnityEngine;

public class MotionScript : MonoBehaviour
{
	void Update ()
	{
		float xMovement = Input.GetAxis ("Horizontal") / 2;
		float yMovement = Input.GetAxis ("Vertical") / 2;

		transform.Translate (xMovement, yMovement , 0);
	}
}
