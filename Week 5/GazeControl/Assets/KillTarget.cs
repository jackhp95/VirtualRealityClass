using UnityEngine;
using System.Collections;
using  UnityEngine.UI;


public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public float timeToSelect = 3.0f;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    private float countDown;
    private float killCount;

    public Text scoreBoard;
    // Use this for initialization
    void Start()
    {
        countDown = timeToSelect;
        var emission = hitEffect.emission;
        emission.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            if (countDown < 0f)
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                //Destroy(target);
               //target = Instantiate(target);
                target.transform.localPosition = new Vector3(5f,5f,5f);
                countDown = timeToSelect;
                killCount++;
                scoreBoard.text = "" + killCount;
            }
            else
            {

                //ToDo: Decrement countdown with Time.deltaTime amount. 
                countDown = countDown - Time.deltaTime;

                // Enable the hitEffect,
                var emission = hitEffect.emission;
                emission.enabled = true;

                // and place it at hit.ponit.
                hitEffect.transform.position = hit.point;
            }

        }
        else
        {
            //ToDo: Reset countdown. Disable hitEffect.
            if (countDown < 0f)
            {
                countDown = timeToSelect;
                var emission = hitEffect.emission;
                emission.enabled = false;

            }
        }
    }
}
