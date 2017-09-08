using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrink : MonoBehaviour {
	Vector3 scale;
	Vector3 position;
	const float grow = 0.01f;
	const float shrink = -0.01f;
	float state = grow;

	// Use this for initialization
	void Start () {
		scale = transform.localScale;
		position = transform.localPosition;
		Renderer rend = gameObject.GetComponent<Renderer>();
		rend.material.SetColor("_Color", Color.green);
	}

	// Update is called once per frame
	void Update () {
		scale.x += state;
		scale.y += state;
		scale.z += state;

		position.x = 5 * Mathf.Sin(Time.fixedTime);
		position.y = 5 * Mathf.Sin(Time.fixedTime);

		if ( scale.x < 1 && state == shrink ) {
			state = grow;
		}
		if ( scale.x > 3 && state == grow ) {
			state = shrink;
		}
		transform.localScale = scale;
		transform.localPosition = position;

	}
}
