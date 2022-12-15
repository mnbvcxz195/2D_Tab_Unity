using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public GameObject CreateCharacter(string playerName)
    {
        Object characterObj = Resources.Load("Sprite/" + playerName);
        GameObject character = (GameObject)Instantiate(characterObj);

        return character;
    }

    public GameObject CreateMonster(string monsterName)
    {
        Object monsterObj = Resources.Load("Sprite/" + monsterName);
        GameObject monster = (GameObject)Instantiate(monsterObj);

        return monster;
    }

   public ParticleSystem CreateHitEffect()
    {
        Object effectObj = Resources.Load("Effect/Hit_Effect");
        GameObject effect = (GameObject)Instantiate(effectObj);

        return effect.GetComponent<ParticleSystem>();
    }

    public GameObject CreateWin()
    {
        Object winObj = Resources.Load("UI/Win");
        GameObject win = (GameObject)Instantiate(winObj);

        return win;
    }

    public GameObject CreateLose()
    {
        Object LoseObj = Resources.Load("UI/Lose");
        GameObject Lose = (GameObject)Instantiate(LoseObj);

        return Lose;
    }
}
