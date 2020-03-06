using UnityEngine;

// This script adds together all even numbers between start and end
public class AddEvenNumbers : MonoBehaviour
{
	// Make these variables public and they can be changed in the inspector
	public int start = 2;
	public int end = 499; 

	// Use this for initialization
	void Start ()
	{
		print ("The sum of the even numbers between " + start + " and " + end + " end is...");

		int sum = 0;
		int i = start;

		while (i <= end)
		{
			// % is modulus, which finds the remainder of division. See also Loops.cs
			// If the remainder of dividing by 2 is zero, i is even
			if (i % 2 == 0)
				sum += i;
			
			// Remember to increment i or you'll have an infinite loop!
			// You can force quit Unity if it freezes 
			i++;
		}
		print (sum);
	}
}