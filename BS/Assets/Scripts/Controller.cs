using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float horizontalSpeed = 5.0F;
    public float verticalSpeed = 5.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //TODO:rotating the object with VR controller 
            // currently moves with mouse cursor position 
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            this.transform.position = new Vector3(h, v, 0);
            //throwing object - needs certain velocity

        }

    }



}
