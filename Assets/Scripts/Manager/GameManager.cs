using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static 
        GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public string playerName = "Char";

    public int level = 1;

    public int gold = 1000;    //�߰�, ����

    public int totalHp = 100;  //����
    public int curHp = 100;    //����, ����

    public void LoadData()
    {
        playerName = PlayerPrefs.GetString("playerName", "Char");

        level = PlayerPrefs.GetInt("level", 1);
        gold = PlayerPrefs.GetInt("gold", 500);
        totalHp = PlayerPrefs.GetInt("totalHp", 100);
        curHp = PlayerPrefs.GetInt("curHp", 100);

    }

    public void SaveData()
    {
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("totalHp", totalHp);
        PlayerPrefs.SetInt("curHp", curHp);
    }
    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public bool SpendGold(int gold)
    {
        if(this.gold >= gold)
        {
            this.gold -= gold;
            return true;
        }

        return false;
    }

    public void IncreaseTotalHp(int addHp)
    {
        totalHp += addHp;
    }

    public void SetCurrentHp(int hp)
    {
        curHp += hp;

        if (curHp > totalHp)
            curHp = totalHp;

        if (curHp < 0)
            curHp = 0;

       //curHp = Mathf.Clamp(curHp, 0, totalHp); ����Ƽ ���̺귯�� ���� ��� curHp�� ������ ��������
    }
}
