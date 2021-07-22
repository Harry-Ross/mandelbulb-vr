using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandelbulbCreator : MonoBehaviour {
	public Material material;
	public const int power = 6;

	public GameObject cube;	

	// Use this for initialization
	void Start () {
		const int iterations = 25;
		const int detail = 25;
		Debug.Log("hello");
		for (int x = -iterations; x < iterations; x++) {
			for (int y = -iterations; y < iterations; y++) {
				for (int z = -iterations; z < iterations; z++) {
					if (inMandelBulb(new Vector3(x / detail, y / detail, z / detail))) {
						Instantiate(cube, new Vector3(x,y,z), transform.rotation);
					}
				}
			}
		}
		Debug.Log("done");
	}
	// your code is shit harry
	// Update is called once per frame
	void Update () {
		
	}

	bool inMandelBulb (Vector3 point) {
		int count = 0;
		Vector3 v = point;
		float r = 0;
		while (count < 25 && r < power) {
			r = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2) + Mathf.Pow(v.z, 2));
            v = vectorPower(v, power);
			count++;
		}
		return(r < power);
	}

	Vector3 vectorPower (Vector3 v, int n) {
		float r = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2) + Mathf.Pow(v.z, 2));
		
		float circleWithALineThroughIt = Mathf.Atan2(v.y, v.x);
		float theta = Mathf.Atan2(Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2)), v.z);

		float x = Mathf.Sin(n * theta) * Mathf.Cos(n * circleWithALineThroughIt) * Mathf.Pow(r, n);
		float y = Mathf.Sin(n * theta) * Mathf.Sin(n * circleWithALineThroughIt) * Mathf.Pow(r, n);
		float z = Mathf.Cos(n * theta) * Mathf.Pow(r, n);

		Vector3 newVector = new Vector3(x, y, z);
		return newVector;
	}
}
