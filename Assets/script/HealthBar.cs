using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Image health_bar;
    private float current_health;
    private float max_healt;

    private void Awake()
    {
        max_healt = Ship.vitality;    
    }

    void Start()
    {
        current_health = Ship.vitality / max_healt;
    }

    void Update()
    {
        current_health = Ship.vitality / max_healt;
        health_bar.fillAmount = current_health;
    }
}
