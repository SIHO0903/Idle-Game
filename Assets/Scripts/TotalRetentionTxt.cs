using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TotalRetentionTxt : MonoBehaviour
{
    [SerializeField] GameObject[] mergeObjects;
    EquipmentInfo[][] equipmentInfos;
    EquipmentInfo[] equipmentInfo;

    float totalRetention = 0;
    public static float textUpdatefloat = -1;
    string type;
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        equipmentInfos = new EquipmentInfo[mergeObjects.Length][];
        for (int i = 0; i < mergeObjects.Length; i++)
        {
            equipmentInfos[i] = mergeObjects[i].GetComponentsInChildren<EquipmentInfo>(true);
        }
    }
    private void OnEnable()
    {
        totalRetention = 0;
    }
    private void Update()
    {
        if (textUpdatefloat != totalRetention)
        {
            totalRetention = 0;
            for (int i = 0; i < mergeObjects.Length; i++)
            {
                if (equipmentInfos[i][0].transform.parent.gameObject.activeSelf)
                {
                    equipmentInfo = equipmentInfos[i];
                }
            }
            for (int i = 0; i < equipmentInfo.Length; i++)
            {
                if (equipmentInfo[i].level==0)
                    continue;
                totalRetention = totalRetention + equipmentInfo[i].retentionEffect + (equipmentInfo[i].retentionIncrement * equipmentInfo[i].level);
            }
            textUpdatefloat = totalRetention;
            switch (equipmentInfo[0].equipType)
            {
                case EquipmentEnum.EquipType.Weapon:
                    type = "공격력 ";
                    GameManager.instance.player.retentionDamage1 = totalRetention;
                    break;
                case EquipmentEnum.EquipType.Defense:
                    type = "체력 ";
                    GameManager.instance.player.retentionHealth1 = totalRetention;
                    break;
                case EquipmentEnum.EquipType.Gloves:
                    type = "체력 ";
                    GameManager.instance.player.retentionHealth2 = totalRetention;
                    break;
                case EquipmentEnum.EquipType.Ring:
                    type = "공격력 ";
                    GameManager.instance.player.retentionDamage2 = totalRetention;
                    break;
            }

            text.text = "총 보유효과 : " + type + totalRetention.ToString() + "%";
        }

    }

}
