using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour {

	GameObject WalkTarget;

	// Use this for initialization
	void Start () {
		WalkTarget = GameObject.Find("WalkTarget");
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if(Physics.Raycast(transform.position, Camera.main .transform .rotation * Vector3.forward, out hit)){
			// print("Found an object - distance: " + hit.distance);
		}
		
		Debug.DrawLine(transform.position, hit.point);
		WalkTarget.transform.position = hit.point;
	}
}
