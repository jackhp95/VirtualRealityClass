using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise1 : MonoBehaviour {
	Vector3 scale;

	// Use this for initialization
	void Start () {
		scale = transform.localScale;
		Renderer rend = gameObject.GetComponent<Renderer>();
		rend.material.SetColor("_Color", Color.green);
	}

	// Update is called once per frame
	void Update () {
		Vector3 inc = new Vector3(0.01f, 0.01f, 0.01f);
		Vector3 dec = new Vector3(-0.01f, -0.01f, -0.01f);
		Vector3 state = inc;

		scale += state;

		if ( scale.x < 1 && state == dec ) {
			state = inc;
		}
		if ( scale.x > 3 && state == inc ) {
			state = dec;
		}
	}
}
