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

    public int gold = 1000;    //추가, 삭제

    public int totalHp = 100;  //증가
    public int curHp = 100;    //증가, 감소

    public int characterIdx = 0;// 0 -> mage, 1 -> skeletone

    public int playernum = 0;

    /*//캐릭터 1
    public int mageHp = 100;
    public string mageImg = "Character";

    //캐릭터 2
    public int skeletoneHp = 130;
    public string skeletoneImg = "Character2";*/

    public Player[] playerDatas = new Player[]
    {
        new Player("Player1", 1, 500, 100, 100),
        new Player("Player2", 1, 700, 130, 130),
        new Player("Player3", 1, 700, 130, 130)
    };

    public Player SetPlayer(int num)
    {
        return playerDatas[num];
    }

    public void LoadData()
    {
        playerName = PlayerPrefs.GetString($"playerName_{characterIdx}", "Char");

        level = PlayerPrefs.GetInt($"level_{characterIdx}", 1);
        gold = PlayerPrefs.GetInt($"gold_{characterIdx}", 500);
        totalHp = PlayerPrefs.GetInt($"totalHp_{characterIdx}", 100);
        curHp = PlayerPrefs.GetInt($"curHp_{characterIdx}", 100);

    }

    public void SaveData()
    {
        PlayerPrefs.SetString($"playerName_{characterIdx}", playerName);
        PlayerPrefs.SetInt($"level_{characterIdx}", level);
        PlayerPrefs.SetInt($"gold_{characterIdx}", gold);
        PlayerPrefs.SetInt($"totalHp_{characterIdx}", totalHp);
        PlayerPrefs.SetInt($"curHp_{characterIdx}", curHp);
    }
    public void AddGold(int gold)
    {
        this.gold += gold;
        SaveData();
    }

    public bool SpendGold(int gold)
    {
        if(this.gold >= gold)
        {
            this.gold -= gold;
            SaveData();
            return true;
        }

        return false;
    }

    public void IncreaseTotalHp(int addHp)
    {
        totalHp += addHp;
        SaveData();
    }

    public void SetCurrentHp(int hp)
    {
        curHp += hp;
        SaveData();

        if (curHp > totalHp)
            curHp = totalHp;

        if (curHp < 0)
            curHp = 0;

       //curHp = Mathf.Clamp(curHp, 0, totalHp); 유니티 라이브러리 속의 기능 curHp의 범위를 지정해줌
    }
}
