using UnityEngine;

// This script prints the first <number> of Fibonacci numbers
public class Fibonacci : MonoBehaviour
{
	public int number = 20;

	// Use this for initialization
	void Start ()
	{
		print ("Here are the first " + number + " Fibonacci numbers");

		// Must be defined outside the loop
		int previousResultA = 0;
		int previousResultB = 1;

		if (number <= 2)
		{
			print("I need a challenge. Look for at least 3 numbers in the sequence");

			//return let's us exit the code early. The rest of this code below will not execute if return is called
			return; 
		}

		//Print the first 2 numbers
		print("The first two numbers are 0 and 1");

		// We start with count at 3 because the first 2 are defined as 0 and 1
		for (int count = 3; count <= number; count++)
		{
			int result = previousResultA + previousResultB;
			print ("Sequence number " + count + " equals " + result);

			//Save the previous results for use in the next calculation
			previousResultA = previousResultB;
			previousResultB = result;
		}
	}
}