using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightRotation : MonoBehaviour
{
    private Vector3 rotate_target_pos;
    private Transform look_target_trans;
    void Start()
    {
        
    }

    void Update()
    {
        rotate_target_pos = GameObject.Find("SightCross").GetComponent<RectTransform>().position;
        look_target_trans = GameObject.Find("Main Camera").GetComponent<Transform>();
        transform.LookAt(look_target_trans);
        transform.RotateAround(rotate_target_pos, new Vector3(0, 0, 2), 20 * Time.deltaTime);
    }
}
