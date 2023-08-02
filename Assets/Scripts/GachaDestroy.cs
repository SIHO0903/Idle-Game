using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaDestroy : MonoBehaviour
{
    [SerializeField] GameObject[] equipType;
    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            switch (transform.GetChild(i).GetComponent<EquipmentInfo>().equipType)
            {
                case EquipmentEnum.EquipType.Weapon:
                    //빨리찾는 알고리즘
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
