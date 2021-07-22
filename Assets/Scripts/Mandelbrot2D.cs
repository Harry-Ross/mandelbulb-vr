using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandelbrot2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	int escapeSteps (float x, float y, int detail) {
		int count = 0;
		float z = 0;
		float rootZ = Mathf.Sqrt(z);

		float newX = x;
		float newY = y;

		while (rootZ < 2.0 && count < detail) {
			// Variable and equation definition
			float xx = newX * newX;
			float yy = newY * newY;
			float twoab = 2 * newX * newY;
			newX = xx - yy + x;
			newY = twoab + y;

			// Defines the distance
			z = Mathf.Sqrt(twoab * twoab + (xx - yy) * (xx - yy));
			rootZ = Mathf.Sqrt(z);

			// Increments the count
			count++;
		}

		return count;
	}
}
