using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Fold : MonoBehaviour
{
    float mouseXPrev;
    float mouseXCur;
    float dist;
    float ori = 0;

    bool held = false;
    float prevX;
    float curX;

    // Start is called before the first frame update
    void Start()
    {
        mouseXCur = Input.mousePosition.x;
    }


    // Update is called once per frame
    void Update()
    {
        mouseXPrev = mouseXCur;
        mouseXCur = Input.mousePosition.x;
        dist = mouseXCur - mouseXPrev;
        if (Input.GetMouseButton(0))
        {
            Vector3 rot = new Vector3(0, 0, -dist);
            ori += dist;
            if (ori > 0 && ori < 180)
            {
                this.transform.Rotate(rot);
            }
            else ori -= dist;
        }
    }
}
