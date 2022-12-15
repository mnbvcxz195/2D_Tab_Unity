using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1
{
    public string MonsterName = "Monster1";

    public int atk = 10;
    public int hp = 30;

    public float delay = 2.5f;

    public int gold = 300;

    public Monster1(string MonsterName, int atk, int hp, float delay, int gold)
    {
        this.MonsterName = MonsterName;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }
}
