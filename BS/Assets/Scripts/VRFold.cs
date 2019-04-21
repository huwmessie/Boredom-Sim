using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRFold : MonoBehaviour
  {
    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_BooleanAction;

    public Transform motionSource;

    bool held = false;
    float prevX;
    float curX;
    float ori = 0;
    

    // Start is called before the first frame update
    private void Awake()
    {
        //m_BooleanAction = SteamVR_Actions._default.Send;
    }

    private void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            held = true;
            curX = motionSource.position.x;
        }
        if (m_BooleanAction.GetStateUp(SteamVR_Input_Sources.Any))
        {
            held = false;
        }

        if (held)
        {
            print("being held");
            prevX = curX;
            curX = motionSource.position.x;
            float dist = (curX - prevX)*100;
            print(dist);
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


