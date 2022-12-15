using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string playerName;

    public int level;
    public int gold;

    public int totlaHp;
    public int curHp;

    public Player(string playerName, int level, int gold, int totlaHp, int curHp)
    {
        this.playerName = playerName;
        this.level = level;
        this.gold = gold;
        this.totlaHp = totlaHp;
        this.curHp = curHp;
    }
}
