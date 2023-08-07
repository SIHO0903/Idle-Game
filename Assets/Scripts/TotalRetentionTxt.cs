using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TotalRetentionTxt : MonoBehaviour
{
    [SerializeField] GameObject[] mergeObjects;
    EquipmentInfo[][] equipmentInfos;
    //EquipmentInfo[] equipmentInfo;

    float totalRetention = 0;
    public static float textUpdatefloat = -1;
    string type;
    [SerializeField] TextMeshProUGUI text;
    private void Awake()
    {
        equipmentInfos = new EquipmentInfo[mergeObjects.Length][];
        for (int i = 0; i < mergeObjects.Length; i++)
        {
            equipmentInfos[i] = mergeObjects[i].GetComponentsInChildren<EquipmentInfo>(true);
        }
    }
    private void OnEnable()
    {
        RetentionEffectApply();
    }
    private void Update()
    {
        RetentionEffectApply();
        TotalRetentionTxtUpdate();
    }
    public void RetentionEffectApply()
    {
        if (textUpdatefloat != totalRetention)
        {
            totalRetention = 0;
            for (int i = 0; i < mergeObjects.Length; i++)
            {
                for (int j = 0; j < equipmentInfos[i].Length; j++)
                {
                    if (equipmentInfos[i][j].level == 0)
                        continue;
                    totalRetention = totalRetention + equipmentInfos[i][j].retentionEffect + (equipmentInfos[i][j].retentionIncrement * equipmentInfos[i][j].level);

                }
                textUpdatefloat = totalRetention;
                switch (equipmentInfos[i][0].equipType)
                {
                    case EquipmentEnum.EquipType.Weapon:
                        GameManager.instance.player.retentionDamage1 = totalRetention;
                        break;
                    case EquipmentEnum.EquipType.Defense:
                        GameManager.instance.player.retentionHealth1 = totalRetention;
                        break;
                    case EquipmentEnum.EquipType.Gloves:
                        GameManager.instance.player.retentionHealth2 = totalRetention;
                        break;
                    case EquipmentEnum.EquipType.Ring:
                        GameManager.instance.player.retentionDamage2 = totalRetention;
                        break;
                }

                totalRetention = 0;
            }
        }

    }

    private void TotalRetentionTxtUpdate()
    {
        for (int i = 0; i < mergeObjects.Length; i++)
        {
            if (equipmentInfos[i][0].transform.parent.gameObject.activeSelf)
            {
                switch (equipmentInfos[i][0].equipType)
                {
                    case EquipmentEnum.EquipType.Weapon:
                        type = "공격력 ";
                        totalRetention = GameManager.instance.player.retentionDamage1;
                        break;
                    case EquipmentEnum.EquipType.Defense:
                        type = "체력 ";
                        totalRetention = GameManager.instance.player.retentionHealth1;
                        break;
                    case EquipmentEnum.EquipType.Gloves:
                        type = "체력 ";
                        totalRetention = GameManager.instance.player.retentionHealth2;
                        break;
                    case EquipmentEnum.EquipType.Ring:
                        type = "공격력 ";
                        totalRetention = GameManager.instance.player.retentionDamage2;
                        break;
                }
                text.text = "총 보유효과 : " + type + totalRetention.ToString() + "%";
            }
        }
    }
}
