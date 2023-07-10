using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUp : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 endPos;
    float curTime;
    [SerializeField] float lerpTime;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        this.rectTransform.position = startPos;
        curTime = 0;

    }
    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime >= lerpTime)
        {
            curTime = lerpTime;
        }
        transform.position = Vector2.Lerp(startPos, endPos, curTime / lerpTime);

        
    }

}
