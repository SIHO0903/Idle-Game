using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    public static TestPool instance;

    public enum ObjectType { Player, Enemy, Boss }

    [System.Serializable]
    public struct PrefabPoolData
    {
        public ObjectType objectType;
        public GameObject prefab;
        public int initialPoolSize;
    }

    public List<PrefabPoolData> prefabPools;
    private Dictionary<ObjectType, List<GameObject>> objectPools;

    private void Awake()
    {
        instance = this;
        objectPools = new Dictionary<ObjectType, List<GameObject>>();

        // PrefabPools �����͸� ������� ������Ʈ Ǯ �ʱ�ȭ
        foreach (PrefabPoolData poolData in prefabPools)
        {
            List<GameObject> poolList = new List<GameObject>();
            for (int i = 0; i < poolData.initialPoolSize; i++)
            {
                GameObject obj = Instantiate(poolData.prefab, transform);
                obj.SetActive(false);
                poolList.Add(obj);
            }

            objectPools[poolData.objectType] = poolList;
        }
    }

    public GameObject GetObject(ObjectType objectType)
    {
        List<GameObject> poolList;
        if (objectPools.TryGetValue(objectType, out poolList))
        {
            GameObject select = null;
            foreach (GameObject item in poolList)
            {
                if (!item.activeSelf)
                {
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }

            // �������� ���� Ȱ��ȭ ������ ��� ���� ���� �� ����Ʈ�� �߰�
            if (!select)
            {
                foreach (PrefabPoolData poolData in prefabPools)
                {
                    if (poolData.objectType == objectType)
                    {
                        select = Instantiate(poolData.prefab, transform);
                        poolList.Add(select);
                        break;
                    }
                }
            }

            return select;
        }

        Debug.LogError("Object type not found in pool!");
        return null;
    }

}
