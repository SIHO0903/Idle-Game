using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//오브젝트 풀링
public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    //프리팹 저장
    public GameObject[] playerPrefabs;
    List<GameObject>[] playerPools;

    public GameObject[] enemyPrefabs;
    List<GameObject>[] enemyPools;

    public GameObject[] bossPrefabs;
    List<GameObject>[] bossPools;
    private void Awake()
    {
        instance = this;
        //프리팹의 길이에 따라 List선언
        playerPools = new List<GameObject>[playerPrefabs.Length];

        //List 초기화
        for (int i = 0; i < playerPools.Length; i++)
        {
            playerPools[i] = new List<GameObject>();
        }

        enemyPools = new List<GameObject>[enemyPrefabs.Length];

        for (int i = 0; i < enemyPools.Length; i++)
        {
            enemyPools[i] = new List<GameObject>();
        }

        bossPools = new List<GameObject>[bossPrefabs.Length];

        for (int i = 0; i < bossPools.Length; i++)
        {
            bossPools[i] = new List<GameObject>();
        }
    }
    public GameObject PlayerGet(int index)
    {
        GameObject select = null;

        //index해당하는 프리팹 비활성화시 활성화로 전환
        foreach (GameObject item in playerPools[index])
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

            select = Instantiate(playerPrefabs[index], transform);
            playerPools[index].Add(select);
        }

        return select;
    }

    public GameObject EnemyGet(int index)
    {
        GameObject select = null;

        //index해당하는 프리팹 비활성화시 활성화로 전환
        foreach (GameObject item in enemyPools[index])
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

            select = Instantiate(enemyPrefabs[index], transform);
            enemyPools[index].Add(select);
        }

        return select;
    }

    public GameObject BossGet(int index)
    {
        GameObject select = null;

        foreach (GameObject item in bossPools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {

            select = Instantiate(bossPrefabs[index], transform);
            bossPools[index].Add(select);
        }

        return select;
    }
}
