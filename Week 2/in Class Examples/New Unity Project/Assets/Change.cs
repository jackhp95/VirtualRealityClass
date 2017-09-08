using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Change: MonoBehaviour {
  Vector3 position;

  void Start() {
    gameObject.transform.localScale = new Vector3 (5,5,5);
    transform.position = new Vector3(0,2,0);
    // transform.rotation = Quaternion.Euler(0, 30, 0);
    position = transform.localPosition;

  }

  void Update() {
    position.x += 0.1f;
    transform.position = position;

  }

}
