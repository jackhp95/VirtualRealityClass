using UnityEngine;
using System.Collections.Generic;

using System.Collections;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public GameObject Tube;

    void Start()
    {
        float x = -90;
        float y = 0;

        GameObject a = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
        a.transform.parent = this.gameObject.transform;

        x = -72;

        while (y < 360)
        {
            GameObject b = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
            b.transform.parent = this.gameObject.transform;
            y += 60;
        }

        // x = -60;
        // y = 0;

        // while (y < 360)
        // {
        //     GameObject c = Instantiate(Tube, Tube.transform.position, Quaternion.Euler((x + 6), y, 0));
        //     c.transform.parent = this.gameObject.transform;
        //     y += 30;

        //     GameObject d = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
        //     d.transform.parent = this.gameObject.transform;
        //     y += 30;
        // }

        // x = -42;
        // y = 0;

        // while (y < 360)
        // {
        //     GameObject e = Instantiate(Tube, Tube.transform.position, Quaternion.Euler((x + 6), y, 0));
        //     e.transform.parent = this.gameObject.transform;
        //     y += 19;

        //     GameObject f = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
        //     f.transform.parent = this.gameObject.transform;
        //     y += 22;

        //     GameObject g = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
        //     g.transform.parent = this.gameObject.transform;
        //     y += 19;

        // }

        // x = -25;
        // y = 0;

        // while (y < 360)
        // {
        //     GameObject h = Instantiate(Tube, Tube.transform.position, Quaternion.Euler((x + 7), y, 0));
        //     h.transform.parent = this.gameObject.transform;
        //     y += 14;

        //     GameObject i = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
        //     i.transform.parent = this.gameObject.transform;
        //     y += 16;

        //     GameObject j = Instantiate(Tube, Tube.transform.position, Quaternion.Euler((x - 3), y, 0));
        //     j.transform.parent = this.gameObject.transform;
        //     y += 16;

        //     GameObject k = Instantiate(Tube, Tube.transform.position, Quaternion.Euler(x, y, 0));
        //     k.transform.parent = this.gameObject.transform;
        //     y += 14;

        // }
    }
    void Update()
    {
        this.gameObject.transform.position = target.position;
    }
}