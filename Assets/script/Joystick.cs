using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public GameObject pivot;
    public float angle_left = 1f;
    public float angle_right = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.RotateAround(pivot.transform.position, new Vector3(angle_right, 0, 0), 1);
        //transform.RotateAround(pivot.transform.position, new Vector3(0, 0, angle_left), 1);
    }
}
