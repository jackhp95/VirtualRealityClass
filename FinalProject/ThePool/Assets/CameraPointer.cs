using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class CameraPointer : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(new Vector3(200, 200, 0));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}