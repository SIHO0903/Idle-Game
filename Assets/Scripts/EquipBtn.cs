using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StatusUIEquipImage
{
    public Image rarityImage;
    public Image equipImage;
    public TextMeshProUGUI lvlTxt;
}
public class EquipBtn : MonoBehaviour
{
    public StatusUIEquipImage[] equipment;
    [HideInInspector] public StatusUIEquipImage getEquipmentUI;
    [HideInInspector] public EquipmentInfo equipmentInfo;

    public void BtnEquip()
    {
        AudioManager.instance.SFXPlayer(AudioManager.SFX.Click);
        switch (equipmentInfo.equipType)
        {
            case EquipmentEnum.EquipType.Weapon:
                UIApply((int)EquipmentEnum.EquipType.Weapon);
                break;
            case EquipmentEnum.EquipType.Defense:
                UIApply((int)EquipmentEnum.EquipType.Defense);
                break;
            case EquipmentEnum.EquipType.Gloves:
                UIApply((int)EquipmentEnum.EquipType.Gloves);
                break;
            case EquipmentEnum.EquipType.Ring:
                UIApply((int)EquipmentEnum.EquipType.Ring);
                break;

        }
    }
    void UIApply(int i)
    {
        //0번 none, 1번 weapon, 2번 defense, 3번 gloves, 4번 ring
        equipment[i-1].rarityImage.color = getEquipmentUI.rarityImage.color;
        equipment[i-1].equipImage.sprite= getEquipmentUI.equipImage.sprite;
        equipment[i-1].lvlTxt.text = getEquipmentUI.lvlTxt.text;
        float mountEffect = equipmentInfo.mountingEffect + (equipmentInfo.mountingIncrement * equipmentInfo.level);
        switch (i-1)
        {
            case 0:
                GameManager.instance.player.mountingDamage1 = mountEffect;
                break;
            case 1:
                GameManager.instance.player.mountingHealth1 = mountEffect;
                break;
            case 2:
                GameManager.instance.player.mountingHealth2 = mountEffect;
                break;
            case 3:
                GameManager.instance.player.mountingDamage2 = mountEffect;
                break;

        }
        
    }
}
