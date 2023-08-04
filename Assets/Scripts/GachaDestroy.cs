using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaDestroy : MonoBehaviour
{
    [SerializeField] GameObject[] equipType;
    private void OnDisable()
    {
        //transform.childCount =20;
        for (int i = 0; i < transform.childCount; i++)
        {
            switch (transform.GetChild(i).GetComponent<EquipmentInfo>().equipType)
            {
                case EquipmentEnum.EquipType.Weapon:
                    //equipType[0].GetComponentsInChildren<EquipmentInfo>()[i].weaponName �������ĭ���մ� ����
                    //transform.GetChild(i).GetComponent<EquipmentInfo>().weaponName ��í������ ����
                    //�Ѱ��� 12�� ���ؾ��� �ٵ� �̰� �ִ��� ���� ���ϰ����
                    //���� ������ �س��� ���ϸ� ���ĭ�� ��Ī�� ������ curAmount�� 1����
                    for (int k = 0; k < equipType[0].GetComponentsInChildren<EquipmentInfo>().Length; k++)
                    {
                        if (transform.GetChild(i).GetComponent<EquipmentInfo>().weaponName == equipType[0].GetComponentsInChildren<EquipmentInfo>()[k].weaponName)
                        {
                            if (equipType[0].GetComponentsInChildren<EquipmentInfo>()[k].level == 0)
                                equipType[0].GetComponentsInChildren<EquipmentInfo>()[k].level++;
                            equipType[0].GetComponentsInChildren<EquipmentInfo>()[k].curAmount++;
                        }
                    }
                    break;
                case EquipmentEnum.EquipType.Defense:
                    for (int k = 0; k < equipType[1].GetComponentsInChildren<EquipmentInfo>().Length; k++)
                    {
                        if (transform.GetChild(i).GetComponent<EquipmentInfo>().defenseName == equipType[1].GetComponentsInChildren<EquipmentInfo>()[k].defenseName)
                        {
                            if (equipType[1].GetComponentsInChildren<EquipmentInfo>()[k].level == 0)
                                equipType[1].GetComponentsInChildren<EquipmentInfo>()[k].level++;
                            equipType[1].GetComponentsInChildren<EquipmentInfo>()[k].curAmount++;
                        }
                    }
                    break;
                case EquipmentEnum.EquipType.Gloves:
   
                    for (int k = 0; k < equipType[2].GetComponentsInChildren<EquipmentInfo>().Length; k++)
                    {
                        if (transform.GetChild(i).GetComponent<EquipmentInfo>().glovesName == equipType[2].GetComponentsInChildren<EquipmentInfo>()[k].glovesName)
                        {
                            if (equipType[2].GetComponentsInChildren<EquipmentInfo>()[k].level == 0)
                                equipType[2].GetComponentsInChildren<EquipmentInfo>()[k].level++;
                            equipType[2].GetComponentsInChildren<EquipmentInfo>()[k].curAmount++;
                        }
                    }
                    break;
                case EquipmentEnum.EquipType.Ring:
                    for (int k = 0; k < equipType[3].GetComponentsInChildren<EquipmentInfo>().Length; k++)
                    {
                        if (transform.GetChild(i).GetComponent<EquipmentInfo>().ringName == equipType[3].GetComponentsInChildren<EquipmentInfo>()[k].ringName)
                        {
                            if (equipType[3].GetComponentsInChildren<EquipmentInfo>()[k].level == 0)
                                equipType[3].GetComponentsInChildren<EquipmentInfo>()[k].level++;
                            equipType[3].GetComponentsInChildren<EquipmentInfo>()[k].curAmount++;
                        }
                    }
                    break;
            }
        }
    }
 
    //private void OnDisable()
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        Destroy(transform.GetChild(i).gameObject);
    //    }
    //}
}
