using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    [SerializeField] private readonly float defaultHeight = 0.5f;
    public Camera cam;

    private void Resize()
    {
        float headHeight = cam.transform.localPosition.y;
        float scale = defaultHeight / headHeight;
        transform.localScale = Vector3.one * scale;
    }

    void OnEnable()
    {
        Resize();
    }
}
