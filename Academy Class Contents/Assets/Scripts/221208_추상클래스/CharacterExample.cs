using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 추상클래스(abstract)
 * 객체를 생성 할 수 없는 클래스
 * 하나 이상의 추상메서드를 포함하는 클래스
 * 추상메서드는 abstract 키워드를 사용하여 선언
 * 객체를 생성 할 수 없는 클래스.
 * 추상클래스는 멤버 변수를 포함 할 수 있다.
 * 추상클래스도 클래스이기 때문에 다형성 적용됨 
 */
public abstract class CharacterBase_YH
{
    protected DoSample toDo;
    public DoSample TODO { get { return toDo; } set { toDo = value; } }

    public int data;
    public abstract void Somthing();    // 추상메서드
    public void DoSomthing(DoSample _toDo = null)
    {
        if (_toDo != null)
        {
            toDo = _toDo;
        }
        toDo(); // 이런식으로 실행
    }
}

public class Character_YH : CharacterBase_YH
{
    public override void Somthing()
    {
        Debug.Log("character");
    }
}

public class Monster : CharacterBase_YH
{
    public override void Somthing()
    {
        Debug.Log("Monster");
    }
}

public class CharacterExample : MonoBehaviour
{
    private void Start()
    {
        // 추상클래스라서 이렇게 사용하면 에러가 발생한다.
        //CharacterBase_YH test = new CharacterBase_YH();
        
        List<CharacterBase_YH> characterList = new List<CharacterBase_YH>();
        // 다형성 적용가능 - 자료구조 하나로 관리 가능
        CharacterBase_YH charBase = new Character_YH();
        CharacterBase_YH charBase2 = new Monster();
        characterList.Add(charBase);
        characterList.Add(charBase2);
        for (int i = 0; i < characterList.Count; i++)
        {
            // 다형성을 적용했으므로 할당한 클래스의 somthing함수가 호출
            characterList[i].Somthing();
        }
        characterList[0].TODO = SkillTypeA_YH.Attact;
        characterList[1].TODO = SkillTypeA_YH.SpeedUP;
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].TODO();    // 할당된 함수가 호출
        }
        characterList[0].DoSomthing();  // 파워업 호출
        characterList[0].DoSomthing(SkillTypeA_YH.SpeedUP); // 스피드업 호출

        Debug.Log("---------------------------------------");
        // 몬스터객체를 만들어서 베이스타입으로 형변환 후 스킬실행
        Monster d1 = new Monster();
        CharacterBase_YH ch = d1 as CharacterBase_YH;
        ch.DoSomthing(SkillTypeA_YH.PowerUP);
    }
}