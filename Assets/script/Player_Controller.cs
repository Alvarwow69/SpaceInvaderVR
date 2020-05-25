using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player_Controller : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("joystick button 4"))
            print("ok");
        Vector3 leftPosition = InputTracking.GetLocalPosition(XRNode.LeftHand);
        Quaternion leftRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
        print(leftPosition);
    }
}
