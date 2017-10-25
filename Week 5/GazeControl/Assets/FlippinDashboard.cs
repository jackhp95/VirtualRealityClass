using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippinDashboard : MonoBehaviour
{
    private HeadGesture gesture;
    private GameObject dashBoard;
    private bool open = true;
    private Vector3 startRotation;
    // Use this for initialization
	
    void Start()
    {
        gesture = GetComponent<HeadGesture>();
        dashBoard = GameObject.Find("Dashboard");
        print(dashBoard.name);
        startRotation = dashBoard.transform.eulerAngles;
        print("startrotation" + startRotation);
    }
    // Update is called once per frame
    void Update()
    {

        if (gesture.isFacingDown)
        {
            OpenDashboard();
            // print("open" + dashBoard.transform.eulerAngles);
        }
        else
        {
            CloseDashboard();
            // print("close" + dashBoard.transform.eulerAngles);
        }
    }
    private void CloseDashboard()
    {
        if (open)
        {
            dashBoard.transform.eulerAngles = new Vector3(180f,
           startRotation.y, startRotation.z);
            open = false;
        }
    }
    private void OpenDashboard()
    {
        if (!open)
        {
            dashBoard.transform.eulerAngles = startRotation;
            open = true;
        }
    }
}
