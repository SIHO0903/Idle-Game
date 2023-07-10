using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    TextMeshProUGUI statusUI;
    public enum type { BasicDamage,EndDamage,MaxHealth,HealthRecovery,AttackSpeed,CriticalChance,CriticalDamage }
    public type statusType;
    void Awake()
    {
        statusUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        switch (statusType)
        {
            case type.BasicDamage:
                statusUI.text = GameManager.instance.player.damage.ToString();
                break;
            case type.EndDamage:
                statusUI.text = GameManager.instance.player.endDamage.ToString();
                break;
            case type.MaxHealth:
                statusUI.text = GameManager.instance.player.maxHealth.ToString();
                break;
            case type.HealthRecovery:
                statusUI.text = GameManager.instance.player.healthRecovery.ToString();
                break;
            case type.AttackSpeed:
                statusUI.text = GameManager.instance.player.fireRate.ToString();
                break;
            case type.CriticalChance:
                statusUI.text = GameManager.instance.player.criticalChance.ToString();
                break;
            case type.CriticalDamage: 
                statusUI.text = GameManager.instance.player.criticalDamage.ToString();
                break;

        }
    }
}
