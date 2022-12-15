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

    public Monster1[] monsterDatas = new Monster1[]
    {
        new Monster1("Monster1", 10, 30, 2.5f, 300),
        new Monster1("Monster2", 15, 50, 2f, 1000)
    };

    public Monster1 GetRamdomMoster()
    {
        int rand = Random.Range(0, monsterDatas.Length);
        return monsterDatas[rand];
    }

    public Monster1 monsterData;

    GameObject uiTab;

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        UIManager.GetInstance().OpenUI("UITab");

        MemoryPool.instance.InitEffectPool(5);  //Stack

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

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }
            Debug.Log($"{damage} �� ���Ͱ� ����  ���� ü�� : {GameManager.GetInstance().curHp}");
            ShakeCamera.Instance.OnShakeCamera(0.3f, 0.3f);

        }

        Lose();
    }

    public void AttackMonster()
    {
        //var particle = MemoryPool.instance.effectQueue.Dequeue();
        //float randX = Random.Range(-1.2f, 1.2f);
        //float randY = Random.Range(-1.2f, 1.2f);

        MemoryPool.instance.UseEffect(); //Stack

        /*if(MemoryPool.instance.effectQueue.Count >= 0)
        {
            particle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            particle.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);
            particle.SetActive(true);
        }*/
        monsterData.hp--;

        Debug.Log($"MonsterName : {monsterData.MonsterName}    hp : {monsterData.hp}");
        if (monsterData.hp < 0)
        {
            Victory();
        }

    }

    void Victory()
    {
        Debug.Log("�¸�");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);
        ObjectManager.GetInstance().CreateWin();

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("�й�");
        UIManager.GetInstance().CloseUI("UITab");
        ObjectManager.GetInstance().CreateLose();

        if (GameManager.GetInstance().SpendGold(500))
            GameManager.GetInstance().SetCurrentHp(80);

        else
            GameManager.GetInstance().SetCurrentHp(10);


        Invoke("MoveToMain", 2.5f);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    /*public void RemoveEffect()
    {
        var particle = MemoryPool.instance.effectQueue.Dequeue();

        particle.SetActive(false);
    }*/
}
