using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CHARACTER
{
    public string name;
    public byte classType;  // ����, ������ ���
}

// ���⿡�� public�� ���ߵȴ�. �ȱ׷��� �������ϱ� ��ƴٰ� �������.
//�ֳĸ� spcharacter�� public�ε�, �ش� T�� private�� �׷���.
public struct MONSTER
{
    public string name;
    public byte type;               // ���� Ÿ��
    public MONSTER_STATE mState;    // ������ ����
}

public enum MONSTER_STATE
{
    NONE = 0,
    COUNTRY1,
    COUNTRY2,
    COUNTRY3,
}

// �÷��̾�Ը� ��ų�� �ʿ��ϸ� �÷��̾ �����ϵ��� �߰��ϸ� �ȴ�.
public interface ISkill
{
    public void OneSkill();
    public void TwoSkill();
    public void ThreeSkill();
}

/**
 * ���⿡�� where T������ ��ӹ޴� ��ü���� ������ ����.
 */
public class Sp_Character<T> : MonoBehaviour, ISkill
{
    public T data
    {
        // �̷����ϸ� ���ÿ����÷ο� �����ߴµ�
        //get { return data; }
        //set { data = value; }

        // �̷��� �ϸ� ���������� �ȴ�.
        get;set;
    }

    //�亯���� �̰� get set ����� ���� �Ʒ��� �ٸ���. ���� ����� ���� ������ �ϳ� �� �ʿ��ϰ�, �Ʒ� ������ data��ü�� ������ ���ڴٴ� �ǹ��̴�.
    //�� ���Ͱ��� ������, �Ʒ��� ���� ���� ������ ���ο� �ϳ� �� ����� �Ѵ�.
    T data1;
    public T TestData
    {
        // �̷����ϸ� ���ÿ����÷ο� �����ߴµ�
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
        Debug.Log("ĳ���� 1����ų ���");
    }

    public virtual void ThreeSkill()
    {
        Debug.Log("ĳ���� 2����ų ���");
    }

    public virtual void TwoSkill()
    {
        Debug.Log("ĳ���� 3����ų ���");
    }
}
