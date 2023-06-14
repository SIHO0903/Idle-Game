using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float moveSpeed;
    float move;
    Material material;
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        move += Time.deltaTime;
        material.SetTextureOffset("_MainTex", Vector2.right * move* moveSpeed);
    }
}
