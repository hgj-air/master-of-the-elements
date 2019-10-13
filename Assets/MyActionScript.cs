using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MyActionScript : MonoBehaviour
{ 
    // a reference to the action
    public SteamVR_Action_Boolean TriggerActionLeft;
    public SteamVR_Action_Boolean TriggerActionRight;

    public GameObject ControllerLeft;
    public GameObject ControllerRight;
    public ParticleSystem ParticleSys;
    public float ShootVelocityMultiplier;
    
    // Start is called before the first frame update
    void Start()
    {
        TriggerActionLeft.AddOnChangeListener(TriggerChange, SteamVR_Input_Sources.LeftHand);
        TriggerActionRight.AddOnChangeListener(TriggerChange, SteamVR_Input_Sources.RightHand);
    }

    private void TriggerChange(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource, bool newstate)
    {
        if (TriggerActionLeft.state && TriggerActionRight.state)
        {
            ShootElement();
        }
    }

    private void ShootElement()
    {
        ParticleSys.transform.SetPositionAndRotation(GetMedianControllerPosition(),GetMedianControllerQuaternion());    
        ParticleSys.Play();
    }

    private Vector3 GetMedianControllerPosition()
    {
        return Vector3.Lerp(ControllerLeft.transform.position, ControllerRight.transform.position, 0.5f);
    }
    
    private Quaternion GetMedianControllerQuaternion()
    {
        return Quaternion.Lerp(ControllerLeft.transform.rotation, ControllerRight.transform.rotation, 0.5f);
    }
}
