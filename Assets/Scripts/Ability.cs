using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [Header("# Component")]
    [SerializeField] TextMeshProUGUI lvlTxt;
    [SerializeField] TextMeshProUGUI nameTxt;
    [SerializeField] TextMeshProUGUI amntTxt;
    [SerializeField] TextMeshProUGUI btnTxt;
    [SerializeField] Outline clcikEffect;
    Button btn;

    [Header("# Amount")]
    [SerializeField] int lvl;
    [SerializeField] float cost;
    [SerializeField] float costWeight;
    [SerializeField] string name;

    float curClickEffectOutLine;
    float outlineSpeed=15;
    bool isClick;

    [Header("# Upgrade Status")]
    [SerializeField] float upgradeAmnt;
    [SerializeField] bool isPercent;
    float totalUpgradeAmnt;

    [Header("# MaxLevel")]
    [SerializeField] int maxLvl;
    [SerializeField] bool hasMaxLvl;

    private void Awake()
    {
        btn= GetComponent<Button>();
    }
    private void Start()
    {
        nameTxt.text = name;
        cost = 5;
    }
    private void Update()
    {
        if (isClick)
            BtnClickEffect();

        if (cost > GameManager.instance.coin)
        {
            btn.interactable = false;
        }
        else
        {
            btn.interactable = true;
        }
    }

    // 버튼 꾹눌렀을때 자동으로 빠르게 업그레이드되게 하기
    // 끊어서 눌렀을때 이펙트가 연결되게 하기
    private void BtnClickEffect()
    {
        curClickEffectOutLine += Time.deltaTime;
        clcikEffect.effectDistance = new Vector2(Mathf.Sin(curClickEffectOutLine * outlineSpeed) * 10, Mathf.Sin(curClickEffectOutLine * outlineSpeed) * 10);
        if(clcikEffect.effectDistance.x <= 0)
        {
            isClick= false;
            clcikEffect.effectDistance= Vector2.zero;
            curClickEffectOutLine=0;
        }
    }
    void CommonUp()
    {
        GameManager.instance.coin -= Mathf.RoundToInt(cost);
            
        lvl++;
        lvlTxt.text = "Lv." + lvl;

        if (cost >= 100)
            cost += cost * costWeight;
        else
            cost += 5;

        cost = Mathf.Round(cost);
        btnTxt.text = "강화\n" + cost;

        totalUpgradeAmnt += upgradeAmnt;
        totalUpgradeAmnt = Mathf.Round(totalUpgradeAmnt * 10) / 10f;
        if(isPercent)
            amntTxt.text = totalUpgradeAmnt + "%";
        else
            amntTxt.text = totalUpgradeAmnt.ToString();
       
        if (hasMaxLvl && lvl >= maxLvl)
        {
            btn.interactable= false;
        }

        isClick = true;
    }

    public void BtnDamage()
    {

        CommonUp();
        GameManager.instance.player.damage += upgradeAmnt;
    }
    public void BtnHealth()
    {
        CommonUp();
        GameManager.instance.player.health += upgradeAmnt;
    }
    public void BtnHealthRecovery()
    {
        CommonUp();
        GameManager.instance.player.healthRecovery += upgradeAmnt;
    }
    public void BtnAttackSpeed()
    {
        CommonUp();
        GameManager.instance.player.fireRate -= upgradeAmnt;
    }
    public void BtnCriticalChance()
    {
        CommonUp();
        GameManager.instance.player.criticalChance += upgradeAmnt;
    }
    public void BtnCriticalDamage()
    {
        CommonUp();
        GameManager.instance.player.criticalDamage += upgradeAmnt;
    }

}
