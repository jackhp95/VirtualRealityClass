using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {
	float count = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		count += Time.deltaTime; 

	if (count > 3){
		float x = Random.Range(-5, 5);
		float z = Random.Range(-5, 5);

		transform.position = new Vector3(x, 5, z);
		count = 0;
	}
	}
}
