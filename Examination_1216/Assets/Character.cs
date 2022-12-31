using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    string charName;
    ushort age;
    byte sex;
    ushort level;
    float hp;

    public string NAME { get { return charName; } set { charName = value; } }
    public ushort AGE { get { return age; } set { age = value; } }
    public byte SEX { get { return sex; } set { sex = value; } }
    public ushort Level { get { return level; } set { level = value; } }
    public float HP { get { return hp; } set { hp = value; } }

    public Character()
    {
        charName = string.Empty;
        age = 0;
        sex = 0;    // 0은 남자, 1은 여자, 2는 기타 성별
        level = 0;
        hp = 0;
    }
    public void Attack(float _t)
    {
        Debug.Log("공격함수");
    }
    public void Defence(float _t)
    {
        Debug.Log("방어함수");
    }
    public void LevelUP(ushort _level)
    {
        level = _level;
        Debug.Log("LevelUP");
    }
}
