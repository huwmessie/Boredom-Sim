using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Valve.VR;

public class Grabber : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();
    List<GameObject> currentHoldings = new List<GameObject>();

    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_BooleanAction;

    public SteamVR_Input_Sources InputSource;

    ConstraintSource ConstSrc = new ConstraintSource();

    private void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
        ConstSrc.sourceTransform = transform;
        ConstSrc.weight = 1;
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
        ParentConstraint pc = obj.GetComponent<ParentConstraint>();
        if (pc != null)
        {
            currentHoldings.Add(obj);
            pc.AddSource(ConstSrc);
            pc.constraintActive = true;
        }
    }

    void UnconstrainFromSource(GameObject obj)
    {
        ParentConstraint pc = obj.GetComponent<ParentConstraint>();
        for (int i=0; i<pc.sourceCount; i++)
        {
            if (pc.GetSource(i).sourceTransform == ConstSrc.sourceTransform)
            {
                pc.RemoveSource(i);
            }
        }
    }
}
