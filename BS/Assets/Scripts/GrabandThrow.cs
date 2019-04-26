using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabandThrow : MonoBehaviour
{
    public Transform theDest;
    public float horizontalSpeed = 5.0F;
    public float verticalSpeed = 5.0F;
    float velocity;

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Hand").transform;
        this.transform.rotation = Quaternion.identity; //default orientation
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().freezeRotation = true;

        }


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //TODO:rotating the object with VR controller
            // currently moves with mouse cursor position
            //float h = horizontalSpeed * Input.GetAxis("Mouse X");
            //float v = verticalSpeed * Input.GetAxis("Mouse Y");
            //transform.Rotate(v*3, h*3, 0);
            //this.transform.parent = GameObject.Find("Hand").transform;
            //throwing object - needs certain velocity
            velocity = Input.GetAxis("Mouse Y");

        }

    }

    void OnMouseUp()
    {
        if (velocity > 0.1)
        {
            Debug.Log("register velocity");
            //this.transform.position = (10, 0, 0);
        }
        else
        {
            Debug.Log("no velocity");
        }
        //this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
    }
}
