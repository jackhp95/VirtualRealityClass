using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadNod : MonoBehaviour
{

    // Use this for initialization

    public float sensitivity;
    public float tolerance;
    public int duration;
    private float headTolerant;
    private float headRest;
    private float headIs;
    private float headDelta;
    private float trueSensitivity = 1;
    private int nodUp;
    private int nodDown;

    private int scoreInt;

    public Text verb;

    public Text score;


    void Start()
    {
        scoreInt = -1;
        headRest = Camera.main.transform.rotation.x;
        if (sensitivity != 0)
        {
            trueSensitivity = (1 / sensitivity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (tolerance > 0)
        {
            headIs = Camera.main.transform.rotation.x;
            headTolerant = (headRest * tolerance);
            headRest = (headTolerant + headIs) / (tolerance + 1);
        }
        else
        {
            headRest = headIs;
            headIs = Camera.main.transform.rotation.x;
        }

        headDelta = headRest - headIs;

        if ((nodUp > 0) && (nodDown > 0))
        {
            // print("Nod Registered");
            if (verb.text == "NOD")
            {
                verb.text = "SHAKE";
                scoreInt = scoreInt + 2;
                score.text = scoreInt + "";
            }
            nodDown = 0;
            nodUp = 0;
        }
        else if (headDelta > trueSensitivity)
        {
            nodUp = duration;
        }
        else if (headDelta < -trueSensitivity)
        {
            nodDown = duration;
        }

        if (nodUp > 0)
        {
            nodUp--;
        }

        if (nodDown > 0)
        {
            nodDown--;
        }
    }
}
