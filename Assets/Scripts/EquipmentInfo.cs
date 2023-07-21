using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentInfo : EquipmentEnum
{
    public Image image;
    public string rarity;
    public float mountingEffect;
    public float mountingIncrement;
    public float retentionEffect;
    public float retentionIncrement;
    public float weight;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        switch (rarity)
        {
            case "common":
                image.color = Color.white;
                break;
            case "uncommon":
                image.color = Color.green;
                break;
            case "rare":
                image.color = Color.blue;
                break;
            case "unique":
                image.color = Color.cyan;
                break;
            case "regendary":
                image.color = Color.yellow;
                break;
        }
    }
}
