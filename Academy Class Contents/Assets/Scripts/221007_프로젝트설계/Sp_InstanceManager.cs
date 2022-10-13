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
        player.transform.position = Sp_GameHelper.GetHeightMapPos(Vector3.zero); //지형 높이에 상관없는 캐릭터 배치, 생성위치는 csv또는 서버에서 내려받아야됨
        player.transform.SetParent(parent);
    }

    public void CreateMonster(Transform parent)
    {
        
    }

    public void CreateMonster(string _fieldName, Transform monsterParent)
    {
        // 테이블에서 로드한 데이터로 몬스터를 생성 또는 서버에서 내려받은 데이터를 기반으로 생성 (직접하기)
        //몬스터 10마리 생성
        for (int i = 0; i < 10; i++)
        {
            GameObject rcObj = Sp_ResourceManager.instance.GetRcCharacter("TrollGiant");
            GameObject createdObj = GameObject.Instantiate<GameObject>(rcObj);

            // 이렇게 만들면, 자식클래스인 monster에 인터페이스로 구현한 스킬을 넣어도 사용 할 수 없다.
            // 그래서 character에 인터페이스를 상속하고, 자식에게 override로 재정의를 해야한다. 만약 자식에서 new를 해버리면, 부모클래스의 스킬이 실행된다.
            Sp_Character<MONSTER> monster = createdObj.AddComponent<Sp_Monster>();  
            monster.OneSkill();
            monster.TwoSkill();
            monster.ThreeSkill();

            MONSTER tmp = new MONSTER();
            tmp.name = "Monster_" + i;
            tmp.mState = MONSTER_STATE.COUNTRY1;
            tmp.type = 1;
            monster.data = tmp; // 여기에서 왜 스택오버플로우가 뜨지?
            
            Vector3 spawnPos = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), Random.Range(-5, 5));
            createdObj.transform.position = Sp_GameHelper.GetHeightMapPos(spawnPos);
            monster.transform.SetParent(monsterParent);
            monList.Add(monster);
        }
    }
}
