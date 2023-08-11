using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    int questlvl = 1;
    int curProgress;
    int maxProgress;
    string[] questDetails = new string[3];

    int preKillCount;
    int questMainStage = 1;
    int questSubStage = 1;
    TextMeshProUGUI questLvlTxt;
    TextMeshProUGUI questDetailTxt;
    TextMeshProUGUI questProgressTxt;
    Button btn;
    Outline outline;
    CoinDrop coinDrop;
    private void Awake()
    {
        questDetails[0] = "��� ��ȯ";
        questDetails[1] = "�� óġ";
        questDetails[2] = " Ŭ����";
        questLvlTxt = GetComponentsInChildren<TextMeshProUGUI>()[0];
        questDetailTxt = GetComponentsInChildren<TextMeshProUGUI>()[1];
        questProgressTxt = GetComponentsInChildren<TextMeshProUGUI>()[2];
        btn = GetComponent<Button>();
        outline = GetComponent<Outline>();
        coinDrop = GetComponent<CoinDrop>();
    }
    private void Update()
    {
        questLvlTxt.text = "����Ʈ " + questlvl;

        switch (questlvl % 3)
        {
            case 0: //��� ��ȯ
                questDetailTxt.text = questDetails[0];
                maxProgress = 1;
                questProgressTxt.text = string.Format($"( {curProgress} / {maxProgress} )");
                break;
            case 1: // �� óġ
                questDetailTxt.text = questDetails[1];
                maxProgress = 25;
                if (GameManager.instance.killCount == 0)
                    preKillCount = GameManager.instance.killCount;
                if (GameManager.instance.killCount > preKillCount)
                {
                    curProgress++;
                    preKillCount = GameManager.instance.killCount;
                }
                questProgressTxt.text = string.Format($"( {curProgress} / {maxProgress} )");
                break;
            case 2: // �������� Ŭ����
                questDetailTxt.text = questMainStage + " - " + questSubStage + questDetails[2];
                maxProgress = 1;
                if (questMainStage <= GameManager.instance.mainStage && questSubStage < GameManager.instance.subStage)
                {
                    curProgress = maxProgress;
                }
                questProgressTxt.text = " ";
                break;
        }

        if (curProgress >= maxProgress)
        {
            btn.interactable = true;
            outline.effectColor = Color.yellow;
        }
        else
        {
            btn.interactable = false;
            outline.effectColor = new Color(91, 91, 91, 1);
        }
    }
    public void BtnQuestClear()
    {
        curProgress = 0;
        questlvl++;

        if (questlvl % 3 == 2)
        {
            questSubStage += 2;
            if (questSubStage > 10)
            {
                questSubStage = 1;
                questMainStage++;
            }
        }

        coinDrop.InvokeRepeatingCoinDrop();
    }
    public void BtnGachaCount()
    {
        AudioManager.instance.SFXPlayer(AudioManager.SFX.Click);
        if (questlvl % 3 == 0)
            curProgress++;
    }
}
