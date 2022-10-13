using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_Monster : Sp_Character<MONSTER>
{
    public override void OneSkill()
    {
        Debug.Log("몬스터 1번스킬 사용");
    }

    public new void ThreeSkill()
    {
        Debug.Log("몬스터 2번스킬 사용");
    }

    public void TwoSkill()
    {
        Debug.Log("몬스터 3번스킬 사용");
    }

    public void SampleSkill()
    {
        Debug.Log("몬스터 고유 스킬 사용");
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
