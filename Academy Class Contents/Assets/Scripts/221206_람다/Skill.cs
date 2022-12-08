using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DoSkill();
public class Skill : MonoBehaviour
{
    DoSkill doSkill;
    // 스킬할당은 다른곳에서 설정함.
    public DoSkill DOSKILL 
    {
        get { return doSkill; } set { doSkill = value; }
    }

    public void OnSkill()
    {
        if (doSkill != null)
        {
            doSkill();
        }
    }
}
