﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float x = Random.Range(-5, 5);
		float z = Random.Range(-5, 5);

		transform.position = new Vector3(x, 0, z);
	}
}
