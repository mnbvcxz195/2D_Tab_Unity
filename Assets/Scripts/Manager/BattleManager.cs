using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    private static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public Monster1 monsterData;

    GameObject uiTab;

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }

    //2~3초 마다 몬스터가 플레이어 공격
    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHp(-damage);

            GameObject ui =  UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }
            Debug.Log($"{damage} 로 몬스터가 공격  남은 체력 : {GameManager.GetInstance().curHp}");
        }

        Lose();
    }

    public void AttackMonster()
    {
        float randX = Random.Range(-1.2f, 1.2f);
        float randY = Random.Range(-1.2f, 1.2f);

        var particle = ObjectManager.GetInstance().CreateHitEffect();
        particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particle.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);


        monsterData.hp -- ;

        if(monsterData.hp < 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("승리");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("패배");
        UIManager.GetInstance().CloseUI("UITab");

        if(GameManager.GetInstance().SpendGold(500))
            GameManager.GetInstance().SetCurrentHp(80);

        else
            GameManager.GetInstance().SetCurrentHp(10);


        Invoke("MoveToMain", 2.5f);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
