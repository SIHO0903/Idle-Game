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
                    //equipType[0].GetComponentsInChildren<EquipmentInfo>()[i].weaponName 장비칸에잇는 무기
                    //transform.GetChild(i).GetComponent<EquipmentInfo>().weaponName 갓챠햇을때 무기
                    //한개당 12번 비교해야함 근데 이걸 최대한 적게 비교하고싶음
                    //위에 내용을 해내서 비교하면 장비칸에 매칭된 무기의 curAmount를 1증가
                    break;
                case EquipmentEnum.EquipType.Defense:
                    break;
                case EquipmentEnum.EquipType.Gloves:
                    break;
                case EquipmentEnum.EquipType.Ring:
                    break;
            }
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
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
