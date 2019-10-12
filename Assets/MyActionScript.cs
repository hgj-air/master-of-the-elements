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
    public GameObject Enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        TriggerActionLeft.AddOnChangeListener(TriggerChange, SteamVR_Input_Sources.LeftHand);
        TriggerActionRight.AddOnChangeListener(TriggerChange, SteamVR_Input_Sources.RightHand);
        for (int i = -2; i < 3; i++)
        {
            var e = Instantiate(Enemy);
            e.transform.position = new Vector3(-i, 0.2f, 0.5f);
        }
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
        //ParticleSys.transform.position = GetMedianControllerPosition();
        ParticleSys.transform.SetPositionAndRotation(GetMedianControllerPosition(),GetMedianControllerQuaternion());
        ParticleSys.Play();
        //ParticleSys.GetComponent<Rigidbody>().velocity = ShootVelocityMultiplier * GetMedianControllerForwardDirection();
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3 vec = Vector3.Lerp(ControllerLeft.transform.position, ControllerRight.transform.position, 0.5f);
        //Sphere.transform.position = vec;
    }

    private Vector3 GetMedianControllerPosition()
    {
        return Vector3.Lerp(ControllerLeft.transform.position, ControllerRight.transform.position, 0.5f);
    }
    
    private Quaternion GetMedianControllerQuaternion()
    {
        return Quaternion.Lerp(ControllerLeft.transform.rotation, ControllerRight.transform.rotation, 0.5f);
    }

    private Vector3 GetMedianControllerForwardDirection()
    {
        return Vector3.Lerp(ControllerLeft.transform.forward, ControllerRight.transform.forward, 0.5f);
    }
    
}
