using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Grabber : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();
    List<GameObject> currentHoldings = new List<GameObject>();

    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_BooleanAction;

    public SteamVR_Input_Sources InputSource;

    public GameObject MotionSource;

    private Rigidbody rb;

    private void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
        rb = MotionSource.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (m_BooleanAction.GetStateDown(InputSource))
        {
            foreach (GameObject obj in currentCollisions)
            {
                ConstrainToSource(obj);
            }
        }

        if (m_BooleanAction.GetStateUp(InputSource))
        {
            foreach (GameObject obj in currentHoldings)
            {
                UnconstrainFromSource(obj);
            }
            currentHoldings = new List<GameObject>();
        }

    }

    void OnCollisionEnter(Collision col)
    {

        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);
    }

    void OnCollisionExit(Collision col)
    {

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
    }

    void ConstrainToSource(GameObject obj)
    {
        if (obj.GetComponent<FixedJoint>() == null &&
            obj.GetComponent<Rigidbody>() != null)
        {
            FixedJoint fj = obj.AddComponent<FixedJoint>() as FixedJoint;
            fj.breakForce = 2000;
            fj.breakTorque = 2000;
            fj.connectedBody = rb;
            Vector3 posOffset = obj.transform.position - transform.position;
            Vector3 rotOffset = obj.transform.forward - transform.forward;
            currentHoldings.Add(obj);
        }
        
    }

    void UnconstrainFromSource(GameObject obj)
    {
        Destroy(obj.GetComponent<FixedJoint>());
    }
}
