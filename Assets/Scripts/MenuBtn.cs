using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtn : MonoBehaviour
{
    [SerializeField] GameObject popUpUI;
    public void MenuPopUpBtn()
    {
        if (popUpUI.activeSelf)
            popUpUI.SetActive(false);
        else
            popUpUI.SetActive(true);
    }
}
