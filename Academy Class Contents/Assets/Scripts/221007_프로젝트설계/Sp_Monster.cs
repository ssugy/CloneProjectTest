using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Monster : Sp_Character<MONSTER>
{
    public override void OneSkill()
    {
        Debug.Log("���� 1����ų ���");
    }

    public new void ThreeSkill()
    {
        Debug.Log("���� 2����ų ���");
    }

    public void TwoSkill()
    {
        Debug.Log("���� 3����ų ���");
    }

    public void SampleSkill()
    {
        Debug.Log("���� ���� ��ų ���");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
