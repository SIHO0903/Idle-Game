using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("# Status")]
    public float damage;
    public float health;
    public float healthRecovery;
    public float criticalChance;
    public float criticalDamage;
    public float fireRate;
    float curFireRate;

    GameObject dagger;
    void Start()
    {
        curFireRate = fireRate;
    }

    void Update()
    {
        curFireRate -= Time.deltaTime;
        if (curFireRate <= 0 && NearestTarget.target != null)
        {
            dagger = PoolManager.instance.PlayerGet(0);
            dagger.transform.position = transform.position;
            curFireRate = fireRate;
        }
    }
}
