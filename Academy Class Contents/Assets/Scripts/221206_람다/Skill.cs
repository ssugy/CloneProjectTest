using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DoSkill();
public class Skill : MonoBehaviour
{
    DoSkill doSkill;
    // ��ų�Ҵ��� �ٸ������� ������.
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
