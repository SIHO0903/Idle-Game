using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float speed;
    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = Vector2.right*speed;
    }
}
