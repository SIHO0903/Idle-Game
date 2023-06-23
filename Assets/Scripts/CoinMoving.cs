using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMoving : MonoBehaviour
{
    Transform startPosition;
    RectTransform rectEndPosition;
    Transform endPosition;

    float endPosX;
    float curPosX;

    [SerializeField] float lerpTime;
    [SerializeField] float curTime;

    [SerializeField] bool isCoin;
    private void Start()
    {
        if (isCoin)
            rectEndPosition = GameManager.instance.coinPosition;
        else
            rectEndPosition = GameManager.instance.gemPosition;

        endPosition = rectEndPosition.transform;
        endPosX = Mathf.RoundToInt(endPosition.position.x);


    }
    private void OnEnable()
    {
        curTime = 0;
        startPosition = transform;
    }
    void Update()
    {
        curTime += Time.deltaTime;

        if(curTime>=lerpTime)
        {
            curTime = lerpTime;
        }
        transform.position = Vector2.Lerp(startPosition.position, endPosition.position, curTime / lerpTime);

        curPosX = Mathf.RoundToInt(transform.position.x);

        if (endPosX == curPosX)
        {
            GameManager.instance.GetCoin();
            gameObject.SetActive(false);
        }
    }
}
