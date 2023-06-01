using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fireRate;
    float curFireRate;
    public GameObject dagger;
    void Start()
    {
        curFireRate= fireRate;
    }

    void Update()
    {
        curFireRate-=Time.deltaTime;
        if (curFireRate <= 0)
        {
            Instantiate(dagger,transform.position,Quaternion.identity);
            curFireRate = fireRate;
        }
    }
}
