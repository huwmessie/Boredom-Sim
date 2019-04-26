using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Glider : MonoBehaviour
{

    bool flying = true;
    public Rigidbody rb ;
    // Use this for initialization
    void Start()
    {

        //Debug.Log("Fly script added to: " + gameObject.name);
        rb = GetComponent<Rigidbody>();

    }


    // TODO : nose dipping
    // TODO : triggered by mouse velocity
    void Update()
    {
        if(flying) {
            rb.drag = 10;

            transform.position -= transform.forward * Time.deltaTime * 30.0f;
            // control flight speed
            //if (Input.GetButton("Fire1"))
            //    transform.position -= transform.forward * Time.deltaTime * 60.0f;

            transform.Rotate(-0.25f, 0.0f, 0.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        rb.drag = 0;

        flying = false;
    }

}

