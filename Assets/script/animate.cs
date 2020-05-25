using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    public Animation anim;

    private float waitTime = 1.5f;
    private float timer = 0.0f;
    private bool done = false;
    
    void Start()
    {
        anim.Play("spawnhole");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && !done)
        {
            anim.Play("closehole");
            done = true;
        }
    }
}
