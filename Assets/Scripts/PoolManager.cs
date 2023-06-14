using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//������Ʈ Ǯ��
public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    //������ ����
    public GameObject[] playerPrefabs;
    List<GameObject>[] playerPools;

    public GameObject[] enemyPrefabs;
    List<GameObject>[] enemyPools;
    private void Awake()
    {
        instance = this;
        //�������� ���̿� ���� List����
        playerPools = new List<GameObject>[playerPrefabs.Length];

        //List �ʱ�ȭ
        for (int i = 0; i < playerPools.Length; i++)
        {
            playerPools[i] = new List<GameObject>();
        }

        //�������� ���̿� ���� List����
        enemyPools = new List<GameObject>[enemyPrefabs.Length];

        //List �ʱ�ȭ
        for (int i = 0; i < enemyPools.Length; i++)
        {
            enemyPools[i] = new List<GameObject>();
        }
    }
    public GameObject PlayerGet(int index)
    {
        GameObject select = null;

        //index�ش��ϴ� ������ ��Ȱ��ȭ�� Ȱ��ȭ�� ��ȯ
        foreach (GameObject item in playerPools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // �������� ���� Ȱ��ȭ�����Ͻ� ���� ������ ����Ʈ�� �߰�
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

        //index�ش��ϴ� ������ ��Ȱ��ȭ�� Ȱ��ȭ�� ��ȯ
        foreach (GameObject item in enemyPools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // �������� ���� Ȱ��ȭ�����Ͻ� ���� ������ ����Ʈ�� �߰�
        if (!select)
        {

            select = Instantiate(enemyPrefabs[index], transform);
            enemyPools[index].Add(select);
        }

        return select;
    }
}
