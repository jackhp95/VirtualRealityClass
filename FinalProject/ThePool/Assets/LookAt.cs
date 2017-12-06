using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
    void Update()
    {
        Vector3 relativePos = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }
}
