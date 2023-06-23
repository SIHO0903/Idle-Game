using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("# Coin,Gem")]
    public int coin;
    public int gem;
    public RectTransform coinPosition;
    public RectTransform gemPosition;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gemText;
    void Awake()
    {
        instance = this;
    }

    public void GetCoin()
    {
        coin += 5;
        coinText.text = coin.ToString();
    }
}
