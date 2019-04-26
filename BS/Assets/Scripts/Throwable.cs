using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Throwable : MonoBehaviour
{
    private Material _outlineMaterial;

    private const string OutlineWidthKey = "_Outline";
    private const float OutlineWidthValue = 0.3f;

    void Start ()
    {
        _outlineMaterial = GetComponent<Renderer>().materials[1];
        _outlineMaterial.SetFloat(OutlineWidthKey, 0);
    }

    // Shows the outline by setting the width to be a fixed avalue when we are
    // pointing at it.
    public void ShowOutlineMaterial()
    {
        _outlineMaterial.SetFloat(OutlineWidthKey, OutlineWidthValue);
    }

    // Hides the outline by making the width 0 when we are no longer
    // pointing at it.
    public void HideOutlineMaterial()
    {
        _outlineMaterial.SetFloat(OutlineWidthKey, 0);
    }
}