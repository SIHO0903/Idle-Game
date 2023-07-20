using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//오브젝트 풀링
public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    public enum PrefabType { Player,Enemy,Boss,Weapon,Defense,Gloves,Ring }
    PrefabType prefabType;


    [System.Serializable]
    public struct PrefabPoolData
    {
        public GameObject[] prefabs;
        public List<GameObject>[] pools;
    }
    public List<PrefabPoolData> testPrefabs;
    private void Awake()
    {
        instance = this;
        for (int dataIdx = 0; dataIdx < testPrefabs.Count; dataIdx++)
        {
            PrefabPoolData poolData = testPrefabs[dataIdx];
            poolData.pools = new List<GameObject>[poolData.prefabs.Length];


            for (int i = 0; i < poolData.pools.Length; i++)
            {
                poolData.pools[i] = new List<GameObject>();
            }

            testPrefabs[dataIdx] = poolData; 
        }
    }
    public GameObject Get(PrefabType prefabTypes, int index)
    {   
        GameObject select = null;

        //index해당하는 프리팹 비활성화시 활성화로 전환
        foreach (GameObject item in testPrefabs[(int)prefabTypes].pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // 프리팹이 전부 활성화상태일시 새로 생성후 리스트에 추가
        if (!select)
        {

            select = Instantiate(testPrefabs[(int)prefabTypes].prefabs[index], transform);
            testPrefabs[(int)prefabTypes].pools[index].Add(select);
        }

        return select;
    }

}
