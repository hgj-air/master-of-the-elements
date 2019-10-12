using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Mainscript : MonoBehaviour
{
    void Start ()
    {
        // Set the controller reference
    }
     
    void Update ()
    {
        // === NULL REFERENCE === //
        if (Input.GetAxis("Fire1") != 0.00000)
        {
            Debug.Log ("Trigger");
        }
 
    }
}
