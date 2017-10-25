using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonExecuteTest : MonoBehaviour
{
    public Button startButton, stopButton;
    private bool on = false;
    private float timer = 5.0f;
    // Use this for initialization
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        stopButton = GameObject.Find("StopButton").GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            on = !on;
            timer = 5.0f;
        }
        if (on)
        {
            //water hose fires
            startButton.onClick.Invoke();
            startButton.OnPointerEnter(new PointerEventData(EventSystem.current)); //hightlighted
        }
        else
        {
            //water hose stops
            stopButton.onClick.Invoke();
            startButton.OnPointerExit(new PointerEventData(EventSystem.current)); //normal color
        }
    }
}