using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    Button btn;
    [SerializeField] GameObject gaChaingUI;
    [SerializeField] bool isfreeGacha;
    GameObject itemGridLayout;

    static GameObject[] items = new GameObject[20];

    float[] weights = new float[5] { 1, 4, 15, 30, 50 };
    string pickedRarity;

    int freeGachaChance=2;
    private void Awake()
    {
        btn = GetComponent<Button>();
        itemGridLayout = gaChaingUI.transform.GetChild(0).gameObject;

    }
    private void Update()
    {
        if (!isfreeGacha)
        {
            if (GameManager.instance.gem < 1500)
                btn.interactable = false;
        }
        else
        {
            if (freeGachaChance <= 0)
                btn.interactable = false;
        }
    }
    public void gachaBtn()
    {
        gaChaingUI.SetActive(false);

        if (!isfreeGacha)
        {
            if (GameManager.instance.gem >= 1500)
                GameManager.instance.gem -= 1500;
        }
        else
        {
            if (freeGachaChance > 0)
                freeGachaChance--;
        }
        //무료가챠는 하루에 2번만 할수잇게

        GetGacha();
        TotalRetentionTxt.textUpdatefloat--;
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

        for (int i = 0; i < items.Length; i++)
        {
            float curWeight = 0;
            float randomValue = UnityEngine.Random.Range(1, 101);
            for (int j = 0; j < weights.Length; j++)
            {
                curWeight += weights[j];
                if (randomValue <= curWeight)
                {
                    switch (j)
                    {
                        case 0:
                            pickedRarity = "Legendary";
                            break;
                        case 1:
                            pickedRarity = "Unique";
                            break;
                        case 2:
                            pickedRarity = "Rare";
                            break;
                        case 3:
                            pickedRarity = "Uncommon";
                            break;
                        case 4:
                            pickedRarity = "Common";
                            break;
                    }
                    break;
                }
            }
            PoolManager.PrefabType prefabType;

            if (Enum.TryParse(pickedRarity, out prefabType))
            {
                items[i] = PoolManager.instance.Get(prefabType, UnityEngine.Random.Range(0, PoolManager.instance.prefabDatas[(int)prefabType].pools.Length), itemGridLayout.transform);
                items[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                items[i].transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                items[i].transform.position = itemGridLayout.transform.position;

            }
        }

    }
}
