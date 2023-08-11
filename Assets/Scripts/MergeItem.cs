using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MergeItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI retTxt;
    [SerializeField] TextMeshProUGUI eqpTxt;
    [SerializeField] TextMeshProUGUI lvTxt;
    [HideInInspector] public EquipmentInfo equipmentInfo;

    [SerializeField] GameObject mergeObject;
    EquipmentInfo[] equipGroupsInfo;

    public void BtnMerge()
    {
        AudioManager.instance.SFXPlayer(AudioManager.SFX.Click);
        int mergeCount = equipmentInfo.curAmount / equipmentInfo.maxAmount;
        if (mergeCount >= 1)
        {
            equipmentInfo.curAmount -= mergeCount * equipmentInfo.maxAmount;
            equipmentInfo.level += mergeCount;
            retTxt.text = equipmentInfo.retentionEffect + (equipmentInfo.retentionIncrement * equipmentInfo.level) + "%";
            eqpTxt.text = equipmentInfo.mountingEffect + (equipmentInfo.mountingEffect * equipmentInfo.level) + "%";
            lvTxt.text = "Lv" + equipmentInfo.level.ToString();
        }
        TotalRetentionTxt.textUpdatefloat--;
    }
    public void BtnTotalMerge()
    {
        AudioManager.instance.SFXPlayer(AudioManager.SFX.Click);
        equipGroupsInfo = mergeObject.GetComponentsInChildren<EquipmentInfo>();
        foreach(EquipmentInfo equipGroupInfo in equipGroupsInfo)
        {
            int mergeCount = equipGroupInfo.curAmount / equipGroupInfo.maxAmount;
            if (mergeCount >= 1)
            {
                equipGroupInfo.curAmount -= mergeCount* equipGroupInfo.maxAmount;
                equipGroupInfo.level += mergeCount;
            }
        }
        TotalRetentionTxt.textUpdatefloat--;
    }
}
