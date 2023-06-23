using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] bool isClicked;
    Button btn;
    private void Awake()
    {
        btn= GetComponent<Button>();
    }
    public void GameSpeedUp()
    {
        ColorBlock colorBlock = btn.colors;

        isClicked = !isClicked;
        if(isClicked)
        {
            Time.timeScale = 2f;
            colorBlock.normalColor = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            Time.timeScale = 1f;
            colorBlock.normalColor = new Color(1f, 1f, 1f, 0.5f);
        }
        btn.colors = colorBlock;
    }
}
