using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{

    public float endHeight = -5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < endHeight)
        {
            Destroy(gameObject);
        }
    }
}
