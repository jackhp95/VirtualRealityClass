using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public float hitDistScale = 0;
    GameObject CrossHairs;

    // Use this for initialization
    void Start()
    {
        CrossHairs = GameObject.Find("CrossHairs");

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Camera.main.transform.rotation * Vector3.forward, out hit))
        {
            hitDistScale = (0.01f * hit.distance);

            CrossHairs.transform.localScale = new Vector3(hitDistScale, hitDistScale, hitDistScale);
        }

        Debug.DrawLine(transform.position, hit.point);
        CrossHairs.transform.position = hit.point;
    }
}
