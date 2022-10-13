using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CHARACTER
{
    public string name;
    public byte classType;  // 전사, 마법사 등등
}

// 여기에는 public이 들어가야된다. 안그러면 엑세스하기 어렵다고 에러뜬다.
//왜냐면 spcharacter는 public인데, 해당 T는 private라서 그런듯.
public struct MONSTER
{
    public string name;
    public byte type;               // 몬스터 타입
    public MONSTER_STATE mState;    // 몬스터의 상태
}

public enum MONSTER_STATE
{
    NONE = 0,
    COUNTRY1,
    COUNTRY2,
    COUNTRY3,
}

// 플레이어에게만 스킬이 필요하면 플레이어에 구현하도록 추가하면 된다.
public interface ISkill
{
    public void OneSkill();
    public void TwoSkill();
    public void ThreeSkill();
}

/**
 * 여기에서 where T넣으면 상속받는 객체에서 에러가 난다.
 */
public class Sp_Character<T> : MonoBehaviour, ISkill
{
    public T data
    {
        // 이렇게하면 스택오버플로우 에러뜨는데
        //get { return data; }
        //set { data = value; }

        // 이렇게 하면 정상적으로 된다.
        get;set;
    }

    //답변받음 이게 get set 사용이 위와 아래가 다르다. 위의 방법은 내부 변수가 하나 더 필요하고, 아래 변수는 data자체를 변수로 쓰겠다는 의미이다.
    //즉 위와같이 쓰려면, 아래와 같이 변수 선언을 내부에 하나 더 해줘야 한다.
    T data1;
    public T TestData
    {
        // 이렇게하면 스택오버플로우 에러뜨는데
        get { return data1; }
        set { data1 = value; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void OneSkill()
    {
        Debug.Log("캐릭터 1번스킬 사용");
    }

    public virtual void ThreeSkill()
    {
        Debug.Log("캐릭터 2번스킬 사용");
    }

    public virtual void TwoSkill()
    {
        Debug.Log("캐릭터 3번스킬 사용");
    }
}
