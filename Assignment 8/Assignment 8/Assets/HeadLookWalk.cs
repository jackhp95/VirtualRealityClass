using UnityEngine;
using System.Collections;
public class HeadLookWalk : MonoBehaviour
{
    public float velocity = 30.7f;
    private CharacterController controller;

	public bool isWalking = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Clicked())
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            controller.SimpleMove(Camera.main.transform.forward * velocity);
        }
    }
    public bool Clicked()
    {
        return Input.anyKeyDown;
    }
}