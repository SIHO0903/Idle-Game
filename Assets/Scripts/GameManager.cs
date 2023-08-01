using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public int killCount;

    [Header("# Coin,Gem")]
    public int coin;
    public int gem;
    public RectTransform coinPosition;
    public RectTransform gemPosition;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gemText;


    [Header("# Stage")]
    [SerializeField] TextMeshProUGUI stageTxt;
    public enum AA { 쉬움, 중간, 어려움, 매우어려움, 지옥1, 지옥2, 지옥3 }
    public AA type;
    public int mainStage;
    public int subStage;



    WaitForSeconds playerReviveDelay;
    void Awake()
    {
        instance = this;
        playerReviveDelay = new WaitForSeconds(3f);
    }
    private void Update()
    {
        stageTxt.text = string.Format($"​<color=#FABA00>{type}</color> " + mainStage + "-" + subStage);
        if (subStage > 10)
        {
            mainStage++;
            subStage = 1;
            if (mainStage > 10)
            {
                type++;
                mainStage = 1;
            }
        }

        StartCoroutine(PlayerRevive());


    }

    public IEnumerator PlayerRevive()
    {
        if (!player.gameObject.activeSelf)
        {
            yield return playerReviveDelay;
            player.gameObject.SetActive(true);
            player.isLive = true;
            player.health = player.maxHealth;

        }
    }
    public void GetCoin()
    {
        coin += 5; //임시코드 : 가중치이용해서 코인수급증가시키기
        coinText.text = coin.ToString();
    }
}
