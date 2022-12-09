using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    Button btnTab;

    void Start()
    {
        btnTab = GetComponentInChildren<Button>();
        btnTab.onClick.AddListener(OnTap);
    }

    void OnTap()
    {
        Debug.Log("АјАн");
        BattleManager.GetInstance().AttackMonster();
    }

    void OriginColor()
    {
        btnTab.image.color = new Color32(0, 0, 0, 0);
    }

    void ChangeColor()
    {
        btnTab.image.color = new Color32(255, 0, 0, 255);
    }
}
