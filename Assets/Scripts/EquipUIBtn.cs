using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipUIBtn : MonoBehaviour
{
    [Header("# Image")]
    [SerializeField] Image selectedItemImgback;
    [SerializeField] Image selectedItemImg;
    [Header("# Txt")]
    [SerializeField] TextMeshProUGUI retTxt;
    [SerializeField] TextMeshProUGUI eqpTxt;
    [SerializeField] TextMeshProUGUI lvTxt;

    EquipmentInfo equipmentInfo;
    [SerializeField] MergeItem mergeItem;
    [SerializeField] EquipBtn equipBtn;
    Image imageback;
    Image image;

    StatusUIEquipImage statusUIEquipImage;
    private void Start()
    {
        equipmentInfo = GetComponent<EquipmentInfo>();
        imageback = GetComponent<Image>();
        image = transform.GetChild(0).GetComponent<Image>();

        statusUIEquipImage = new StatusUIEquipImage();
        statusUIEquipImage.rarityImage = selectedItemImgback;
        statusUIEquipImage.equipImage = selectedItemImg;
        statusUIEquipImage.lvlTxt = lvTxt;
    }
    public void BtnItemSelect()
    {
        selectedItemImgback.color = imageback.color;
        selectedItemImg.sprite = image.sprite;
        retTxt.text = equipmentInfo.retentionEffect + (equipmentInfo.retentionIncrement * equipmentInfo.level) + "%";
        eqpTxt.text = equipmentInfo.mountingEffect + (equipmentInfo.mountingIncrement * equipmentInfo.level) + "%";
        lvTxt.text = "Lv" + equipmentInfo.level.ToString();
        mergeItem.equipmentInfo = GetItemInfo();
        equipBtn.equipmentInfo = GetItemInfo();
        equipBtn.getEquipmentUI = GetItemUI();
    }

    public EquipmentInfo GetItemInfo()
    {
        return equipmentInfo;
    }
    public StatusUIEquipImage GetItemUI()
    {
        statusUIEquipImage.rarityImage.color = imageback.color;
        statusUIEquipImage.equipImage.sprite = image.sprite;
        statusUIEquipImage.lvlTxt.text = "Lv" + equipmentInfo.level.ToString();
        return statusUIEquipImage;
    }

}
