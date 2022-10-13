using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp_InstanceManager : SingleTon<Sp_InstanceManager>
{
    public List<Sp_Character<CHARACTER>> chaList;
    public List<Sp_Character<MONSTER>> monList;
    public Sp_Player player;
    public void Initialize()
    {
        chaList = new List<Sp_Character<CHARACTER>>();
        monList = new List<Sp_Character<MONSTER>>();
        Sp_ResourceManager.instance.LoadCharacter();
    }

    public void CreatePlayer(string _name, Transform parent)
    {
        GameObject rcObj = Sp_ResourceManager.instance.GetRcCharacter(_name);
        GameObject createdObj = GameObject.Instantiate<GameObject>(rcObj);
        player = createdObj.AddComponent<Sp_Player>();
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        player.tag = "Player";
        player.transform.position = Sp_GameHelper.GetHeightMapPos(Vector3.zero); //���� ���̿� ������� ĳ���� ��ġ, ������ġ�� csv�Ǵ� �������� �����޾ƾߵ�
        player.transform.SetParent(parent);
    }

    public void CreateMonster(Transform parent)
    {
        
    }

    public void CreateMonster(string _fieldName, Transform monsterParent)
    {
        // ���̺��� �ε��� �����ͷ� ���͸� ���� �Ǵ� �������� �������� �����͸� ������� ���� (�����ϱ�)
        //���� 10���� ����
        for (int i = 0; i < 10; i++)
        {
            GameObject rcObj = Sp_ResourceManager.instance.GetRcCharacter("TrollGiant");
            GameObject createdObj = GameObject.Instantiate<GameObject>(rcObj);

            // �̷��� �����, �ڽ�Ŭ������ monster�� �������̽��� ������ ��ų�� �־ ��� �� �� ����.
            // �׷��� character�� �������̽��� ����ϰ�, �ڽĿ��� override�� �����Ǹ� �ؾ��Ѵ�. ���� �ڽĿ��� new�� �ع�����, �θ�Ŭ������ ��ų�� ����ȴ�.
            Sp_Character<MONSTER> monster = createdObj.AddComponent<Sp_Monster>();  
            monster.OneSkill();
            monster.TwoSkill();
            monster.ThreeSkill();

            MONSTER tmp = new MONSTER();
            tmp.name = "Monster_" + i;
            tmp.mState = MONSTER_STATE.COUNTRY1;
            tmp.type = 1;
            monster.data = tmp; // ���⿡�� �� ���ÿ����÷ο찡 ����?
            
            Vector3 spawnPos = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), Random.Range(-5, 5));
            createdObj.transform.position = Sp_GameHelper.GetHeightMapPos(spawnPos);
            monster.transform.SetParent(monsterParent);
            monList.Add(monster);
        }
    }
}
