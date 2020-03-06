using UnityEngine;

// This script prints out all numbers from 1 to 100
// avoiding multiples of the two numbers specificed
public class AvoidMultiples : MonoBehaviour
{
	// Make these variables public and they can be changed in the inspector
	public int start = 1;
	public int end = 100;
	
	public int avoidA = 3;
	public int avoidB = 5;
	
	// Use this for initialization
	void Start ()
	{
		print ("Writing all of the numbers between " + start + " and " + end);
		print ("avoiding multiples of " + avoidA + " and " + avoidB);

		for(int i = start; i <= end; i++)
		{
			//find out if number is a multiple of the avoided numbers
			bool isMultipleOfA = i % avoidA == 0;
			bool isMultipleOfB = i % avoidB == 0;
			
			if (isMultipleOfA || isMultipleOfB)
				print ("Programming is Awesome!");
			else 
				print (i);
		}
	}
}