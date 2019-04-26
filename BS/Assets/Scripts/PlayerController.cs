using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Throwable _grabbedThrowable; // The object we're grabbing
    private Vector3 _currentGrabbedLocation; // The tracked location of our object for us to throw

    void Start()
    {
        _grabbedThrowable = null;
        _currentGrabbedLocation = new Vector3();
    }

    void Update()
    {
        // If we're holding something, we want to keep track of its position
        // so we can later calculate the vector to throw our ball in.
        if (_grabbedThrowable != null)
        {
            _currentGrabbedLocation = _grabbedThrowable.transform.position;
        }
    }

    // Called by the Event System when we click on an object, receives a game object to hold.
    // The object given must have a throwable object, otherwise we don't do anything
    public void HoldGameObject(GameObject throwableObject)
    {
        Throwable throwable = throwableObject.GetComponent<Throwable>();
        if (throwable != null)
        {
            _grabbedThrowable = throwable;
            throwableObject.transform.parent = this.gameObject.transform; // Set object as a child so it'll follow our controller
            _grabbedThrowable.GetComponent<Rigidbody>().isKinematic = true; // Stops physics from affecting the grabbed object
            _currentGrabbedLocation = _grabbedThrowable.transform.position; // Tack the location of our object so we can throw it later
        }
    }

    // Called by the Event System when we release our click on a game object.
    // Release our held object and throw it based off our controller motino
    public void ReleaseGameObject()
    {
        // Only throw an object if we're holding onto something
        if (_grabbedThrowable != null)
        {
            _grabbedThrowable.transform.parent = null; // Un-parent throwable object so it doesn't follow the controller
            Rigidbody rigidBody = _grabbedThrowable.GetComponent<Rigidbody>();
            rigidBody.isKinematic = false; // Re-enables the physics engine.
            Vector3 throwVector = _grabbedThrowable.transform.position - _currentGrabbedLocation; // Get the direction that we're throwing
            rigidBody.AddForce(throwVector * 10, ForceMode.Impulse); // Throws the ball by sending a force
            _grabbedThrowable = null;
        }
    }
}