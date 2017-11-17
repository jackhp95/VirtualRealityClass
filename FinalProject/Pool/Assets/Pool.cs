using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour
{
    public float sensitivity = 1080;

    // buffer is just the radius of the tube + spacing
    public float buffer;
    private float xPool;
    private float yPool;
    private float zPool;

    private float xPast = 0;
    private float yPast = 0;
    private float zPast = 0;

    private int numChildren = 1;


    // Use this for initialization
    void Start()
    {
        // Determine Canvas size -------------------------------------------------I think (buffer - 10) is ((gap - tube) / 2)
        xPool = (((this.gameObject.transform.GetChild(0).transform.position.x / (2 * buffer))) * 2 * buffer) + 10;
        yPool = (((this.gameObject.transform.GetChild(0).transform.position.y / (2 * buffer))) * 2 * buffer) + (buffer / 2);
        zPool = this.gameObject.transform.GetChild(0).transform.position.z;

        // Fill pool
        var prefabTube = this.gameObject.transform.GetChild(0);

        var mapPoint = new Vector3(-buffer, -buffer, zPool);

        var flipper = false;

        this.gameObject.transform.GetChild(0).position = new Vector3(-buffer, buffer, zPool);

        while (mapPoint.x < (xPool * 2))
        {
            while (mapPoint.y < (yPool * 2))
            {
                // create tube at mapPoint ----------------------------------- Assign this tube as child of canvas
                Instantiate(prefabTube, mapPoint, prefabTube.transform.rotation).SetParent(this.gameObject.transform);
                mapPoint.y += (buffer * 2);
                numChildren++;
            }
            // create tube at mapPoint ----------------------------------- Assign this tube as child of canvas
            Instantiate(prefabTube, mapPoint, prefabTube.transform.rotation).SetParent(this.gameObject.transform);
            mapPoint.x += (buffer * 2);
            numChildren++;

            if (flipper == true)
            {
                mapPoint.y = -buffer;
                flipper = false;
            }
            else
            {
                mapPoint.y = 0;
                flipper = true;

            }
        }

        xPool += buffer;
        yPool += buffer;
        zPool += buffer;
    }

    // Update is called once per frame
    void Update()
    {
        // Find current Camera Rotation
        float xNow = Camera.main.transform.rotation.x;
        float yNow = Camera.main.transform.rotation.y;
        float zNow = Camera.main.transform.rotation.z;

        // Find the delta of the past and current Camera rotation
        float yDelta = (-(xPast - xNow) * sensitivity);
        float xDelta = ((yPast - yNow) * sensitivity);
        float zDelta = ((zPast - zNow) * sensitivity);

        for (int i = 0; i < numChildren; i++)
        {
            // Generate new position based on Deltas
            float xPos = this.gameObject.transform.GetChild(i).transform.position.x + xDelta;
            float yPos = this.gameObject.transform.GetChild(i).transform.position.y + yDelta;
            float zPos = this.gameObject.transform.GetChild(i).transform.position.z + zDelta;

            // Bottom left corner is where 0.0 is, 
            // if the item starts in the middle of the screen, 
            // the position is acutally half of the screensize.
            // hence xyxPool being defined in start with position

            // offset approximate tube size with buffer.

            // Reposition tubes that have fallen out  of the pool.

            // bottom / left 
            if (xPos > ((xPool * 2) - buffer)) { xPos -= (xPool * 2); }
            if (yPos > ((yPool * 2) - buffer)) { yPos -= (yPool * 2); }
            if (zPos > ((zPool * 2) - buffer)) { zPos -= (zPool * 2); }

            // top / right
            if (xPos < -buffer) { xPos += (xPool * 2); }
            if (yPos < -buffer) { yPos += (yPool * 2); }
            if (zPos < -buffer) { zPos += (zPool * 2); }

            // Push updated location
            this.gameObject.transform.GetChild(i).transform.position = new Vector3(xPos, yPos, zPos);
        }
        // Set current as past for next frame
        xPast = xNow;
        yPast = yNow;
        zPast = zNow;
    }
}
