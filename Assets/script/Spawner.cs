using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] mob;
    public GameObject player;
    public bool spawn = false;

    [Range (0f, 200f)] public float beam = 1f;
    [Range(0.1f, 3f)] public float delay;
    private readonly int randpts;
    private int randmob;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 10f, delay);
    }

    void Spawn()
    {
        if (!Ship.alive)
        {
            spawn = false;
        }
        if (spawn)
        {
            pos.x = Random.Range((-beam), beam);
            float beampow = (Mathf.Pow(beam, 2));
            float xpow = (Mathf.Pow(pos.x, 2));
            int z = Random.Range(-1, 1);
            pos.z = Mathf.Sqrt(beampow - xpow) * Mathf.Sign(z);
            randmob = Random.Range(0, mob.Length);
            pos.y = 0;/*Random.Range(-20, 20);*/
            Instantiate(mob[randmob], pos, Quaternion.identity);
        }
    }
}