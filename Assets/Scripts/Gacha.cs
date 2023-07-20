using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    Button btn;
    [SerializeField] bool isfreeGacha;


    private void Awake()
    {
        btn= GetComponent<Button>();
    }
    void gachaBtn()
    {
        if (!isfreeGacha)
        {
            if (GameManager.instance.gem>=1500)
                GameManager.instance.gem -= 1500;
            else
                btn.interactable= false;   
        }
        //무료가챠는 하루에 2번만 할수잇게
        GetGacha();
    }

    void GetGacha()
    {

    }
}
