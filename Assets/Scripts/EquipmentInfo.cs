using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentInfo : EquipmentEnum
{
    Image image;
    public string rarity;
    public int level;
    public int curAmount=0;
    public int maxAmount=5;
    public float mountingEffect;
    public float mountingIncrement;
    public float retentionEffect;
    public float retentionIncrement;

    TextMeshProUGUI lvlTxt;
    TextMeshProUGUI amountSliderTxt;
    Slider amountSlider;
    Image weaponImage;
    Button btn;
    private void Awake()
    {
        image = GetComponent<Image>();
        btn = GetComponent<Button>();
        lvlTxt = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        amountSlider = transform.GetChild(0).GetChild(1).GetComponent <Slider>();
        amountSliderTxt = amountSlider.GetComponentInChildren<TextMeshProUGUI>();
        weaponImage = GetComponentsInChildren<Image>()[1];

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
    private void LateUpdate()
    {
        if (level == 0)
        {
            lvlTxt.gameObject.SetActive(false);
            amountSlider.gameObject.SetActive(false);
            btn.interactable = false;
            weaponImage.color = Color.black;
        }
        else
        {
            lvlTxt.gameObject.SetActive(true);
            amountSlider.gameObject.SetActive(true);
            btn.interactable = true;
            weaponImage.color = Color.white;
            lvlTxt.text = "Lv" + level;
            amountSlider.value = curAmount / maxAmount;
            amountSliderTxt.text = curAmount + " / " + maxAmount;
        }
    }
}
