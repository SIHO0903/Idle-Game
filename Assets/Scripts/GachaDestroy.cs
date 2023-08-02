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
                    //equipType[0].GetComponentsInChildren<EquipmentInfo>()[i].weaponName ���ĭ���մ� ����
                    //transform.GetChild(i).GetComponent<EquipmentInfo>().weaponName ��í������ ����
                    //�Ѱ��� 12�� ���ؾ��� �ٵ� �̰� �ִ��� ���� ���ϰ����
                    //���� ������ �س��� ���ϸ� ���ĭ�� ��Ī�� ������ curAmount�� 1����
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
