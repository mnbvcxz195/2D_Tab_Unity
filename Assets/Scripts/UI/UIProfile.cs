using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;
    public TMP_Text txtHp;

    void Start()
    {
        RefreshState();
    }
    public void RefreshState()
    {
            txtLevel.text = $"LV, { GameManager.GetInstance().level}";
            txtName.text = $"{ GameManager.GetInstance().playerName}";
            txtGold.text = string.Format("{0:#,##0}", GameManager.GetInstance().gold) + "g";

            hpBar.maxValue = GameManager.GetInstance().totalHp;
            hpBar.value = GameManager.GetInstance().curHp;

            txtHp.text = $"{hpBar.value} / {hpBar.maxValue}";
    }
}

