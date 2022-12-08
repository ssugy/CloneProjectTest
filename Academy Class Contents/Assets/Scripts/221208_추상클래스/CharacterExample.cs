using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * �߻�Ŭ����(abstract)
 * ��ü�� ���� �� �� ���� Ŭ����
 * �ϳ� �̻��� �߻�޼��带 �����ϴ� Ŭ����
 * �߻�޼���� abstract Ű���带 ����Ͽ� ����
 * ��ü�� ���� �� �� ���� Ŭ����.
 * �߻�Ŭ������ ��� ������ ���� �� �� �ִ�.
 * �߻�Ŭ������ Ŭ�����̱� ������ ������ ����� 
 */
public abstract class CharacterBase_YH
{
    protected DoSample toDo;
    public DoSample TODO { get { return toDo; } set { toDo = value; } }

    public int data;
    public abstract void Somthing();    // �߻�޼���
    public void DoSomthing(DoSample _toDo = null)
    {
        if (_toDo != null)
        {
            toDo = _toDo;
        }
        toDo(); // �̷������� ����
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
        // �߻�Ŭ������ �̷��� ����ϸ� ������ �߻��Ѵ�.
        //CharacterBase_YH test = new CharacterBase_YH();
        
        List<CharacterBase_YH> characterList = new List<CharacterBase_YH>();
        // ������ ���밡�� - �ڷᱸ�� �ϳ��� ���� ����
        CharacterBase_YH charBase = new Character_YH();
        CharacterBase_YH charBase2 = new Monster();
        characterList.Add(charBase);
        characterList.Add(charBase2);
        for (int i = 0; i < characterList.Count; i++)
        {
            // �������� ���������Ƿ� �Ҵ��� Ŭ������ somthing�Լ��� ȣ��
            characterList[i].Somthing();
        }
        characterList[0].TODO = SkillTypeA_YH.Attact;
        characterList[1].TODO = SkillTypeA_YH.SpeedUP;
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].TODO();    // �Ҵ�� �Լ��� ȣ��
        }
        characterList[0].DoSomthing();  // �Ŀ��� ȣ��
        characterList[0].DoSomthing(SkillTypeA_YH.SpeedUP); // ���ǵ�� ȣ��

        Debug.Log("---------------------------------------");
        // ���Ͱ�ü�� ���� ���̽�Ÿ������ ����ȯ �� ��ų����
        Monster d1 = new Monster();
        CharacterBase_YH ch = d1 as CharacterBase_YH;
        ch.DoSomthing(SkillTypeA_YH.PowerUP);
    }
}