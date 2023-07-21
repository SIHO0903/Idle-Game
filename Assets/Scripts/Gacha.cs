using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    Button btn;
    [SerializeField] GameObject gaChaingUI;
    [SerializeField] bool isfreeGacha;

    GameObject itemGridLayout;

    GameObject[] items = new GameObject[20];

    private void Awake()
    {
        btn= GetComponent<Button>();
        itemGridLayout = gaChaingUI.transform.GetChild(0).gameObject;

    }
    public void gachaBtn()
    {
        if (!isfreeGacha)
        {
            if (GameManager.instance.gem>=1500)
                GameManager.instance.gem -= 1500;
            else
                btn.interactable= false;   
        }
        //무료가챠는 하루에 2번만 할수잇게

        GetGacha();
    }

    void GetGacha()
    {
        gaChaingUI.SetActive(true);

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                items[i].SetActive(false);
            }
        }

        System.Array.Clear(items, 0, items.Length);
        //가중치계산후 아이템 20개생성
        for (int i = 0; i < 20; i++)
        {

            items[i] = PoolManager.instance.Get(PoolManager.PrefabType.Weapon, 
                Random.Range(0, PoolManager.instance.prefabDatas[(int)PoolManager.PrefabType.Weapon].pools.Length),itemGridLayout.transform);
            
            items[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            items[i].transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            items[i].transform.position = itemGridLayout.transform.position;
            //items[i].GetComponent<EquipmentInfo>().rarity
        }

    }
}
