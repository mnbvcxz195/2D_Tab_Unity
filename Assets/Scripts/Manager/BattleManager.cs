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

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        StartCoroutine("BattleProgress");
    }

    //2~3�� ���� ���Ͱ� �÷��̾� ����
    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHp(-damage);
            Debug.Log($"{damage} �� ���Ͱ� ����  ���� ü�� : {GameManager.GetInstance().curHp}");
        }

        Lose();
    }

    void Victory()
    {

    }

    void Lose()
    {
        Debug.Log("�й�");
    }
}
