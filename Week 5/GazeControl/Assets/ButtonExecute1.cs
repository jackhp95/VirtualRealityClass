using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonExecute1 : MonoBehaviour
{

    Button hitButton, currentButton;

    public float timerStart;

    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Button")
        {

            hitButton = hit.transform.parent.gameObject.GetComponent<Button>();

            if (currentButton != hitButton)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                    hitButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                    // Unhighlight Current Button
                    if (currentButton != null)
                    {
                        currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                    }
                }
                else
                {
                    currentButton = hitButton;

                    currentButton.onClick.Invoke();
                }
            }
        }
        else
        {
            timer = timerStart;
        }

    }
}
