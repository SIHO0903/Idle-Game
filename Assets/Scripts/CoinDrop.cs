using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    GameObject coinObject;
    [SerializeField] int minCoin;
    [SerializeField] int maxCoin;
    int coinCount;
    int curCoinCount = 0;
    [SerializeField] bool isGem;
    private void OnEnable()
    {
        coinCount = Random.Range(minCoin, maxCoin);
    }
    void CoinPopUp()
    {
        if(isGem)
            coinObject = PoolManager.instance.Get(PoolManager.PrefabType.Player, 2);
        else
            coinObject = PoolManager.instance.Get(PoolManager.PrefabType.Player, 1);

        coinObject.transform.position = transform.position;
        curCoinCount++;
        if (curCoinCount >= coinCount)
        {
            curCoinCount = 0;
            CancelInvoke("CoinPopUp");
        }

    }
    public void InvokeRepeatingCoinDrop()
    {
        InvokeRepeating("CoinPopUp", 0f, 0.1f);

    }
}
