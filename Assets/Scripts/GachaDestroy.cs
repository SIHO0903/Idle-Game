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
                    //equipType[0].GetComponentsInChildren<EquipmentInfo>()[i].weaponName 무기장비칸에잇는 무기
                    //transform.GetChild(i).GetComponent<EquipmentInfo>().weaponName 갓챠햇을때 무기
                    //한개당 12번 비교해야함 근데 이걸 최대한 적게 비교하고싶음
                    //위에 내용을 해내서 비교하면 장비칸에 매칭된 무기의 curAmount를 1증가
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
