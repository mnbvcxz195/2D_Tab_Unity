using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Monster1
{
    public string MonsterName;

    public int atk;
    public int hp;

    public float delay;

    public int gold;

    public Monster1(string MonsterName, int atk, int hp, float delay, int gold)
    {
        this.MonsterName = MonsterName;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }
}
