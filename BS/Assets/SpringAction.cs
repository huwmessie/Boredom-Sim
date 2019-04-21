using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SpringAction : MonoBehaviour
{
    Vector3 offset;
    public Transform target;
    private ParentConstraint pc;
    bool bindWhenClose = false;

    List<GameObject> currentCollisions = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<ParentConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bindWhenClose)
        {
            offset = transform.position - target.position;
            offset *= 0.85f;
            transform.position = target.position + offset;
            if (offset.magnitude < 0.02)
            {
                bindWhenClose = false;
                pc.constraintActive = true;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        pc.constraintActive = false;
        currentCollisions.Add(col.gameObject);
        bindWhenClose = false;
    }

    private void OnCollisionExit(Collision col)
    {
        currentCollisions.Remove(col.gameObject);
        if (currentCollisions.Count == 0)
            bindWhenClose = true;
    }


}
