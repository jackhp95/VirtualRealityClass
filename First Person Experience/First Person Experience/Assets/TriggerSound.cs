using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource hitSound;
    // Use this for initialization
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        print("start");
    }
    void OnTriggerEnter(Collider other)
    {
        hitSound.Play();
        print("land played");
    }
    void OnCollisionEnter(Collision collision)
    {
        print("collisionenter");
    }
}
