using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadShake : MonoBehaviour
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
    private int shakeLeft;
    private int shakeRight;

	private int scoreInt;

    public Text verb;

	public Text score;


    void Start()
    {
		scoreInt = 0;
        headRest = Camera.main.transform.rotation.y;
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
            headIs = Camera.main.transform.rotation.y;
            headTolerant = (headRest * tolerance);
            headRest = (headTolerant + headIs) / (tolerance + 1);
        }
        else
        {
            headRest = headIs;
            headIs = Camera.main.transform.rotation.y;
        }

        headDelta = headRest - headIs;

        if ((shakeLeft > 0) && (shakeRight > 0))
        {
            // print("Shake Registered");
            if (verb.text == "SHAKE")
            {
                verb.text = "NOD";
				scoreInt = scoreInt + 2;
                score.text = scoreInt + "";
            }
            shakeRight = 0;
            shakeLeft = 0;
        }
        else if (headDelta > trueSensitivity)
        {
            shakeLeft = duration;
        }
        else if (headDelta < -trueSensitivity)
        {
            shakeRight = duration;
        }

        if (shakeLeft > 0)
        {
            shakeLeft--;
        }

        if (shakeRight > 0)
        {
            shakeRight--;
        }
    }
}
