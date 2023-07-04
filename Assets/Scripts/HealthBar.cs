using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider healthBar;
    
    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    public void HealthBarUpdate(float curHealth, float maxHealth)
    {
        healthBar.value = curHealth / maxHealth;
    }
}
