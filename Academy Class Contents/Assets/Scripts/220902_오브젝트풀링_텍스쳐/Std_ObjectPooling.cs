using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_ObjectPooling : MonoBehaviour
{
    List<Std_0812_Monster> monsterList;

    private void Awake()
    {
        monsterList = new List<Std_0812_Monster>();
        // 활성화된 게임오브젝트만 존재하는 리스트와 비활성화된 게임 오브젝트만 존재하는 리스트를 동시에 사용하여 관리 할 수 있다.
    }

    private void Start()
    {
        // 10마리 생성
        for (int i = 0; i < 10; i++)
        {
            Std_0812_Monster monsterScript = CreateMonster("TrollGiant_");
            //생성한 몬스터의 이름과 위치를 변경(위치는 랜덤)
            monsterScript.gameObject.name = $"TrollGiant_{i}";
            monsterScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
    }

    /**
     * 오브젝트 풀링을 게임오브젝트를 반환하지 않고, 
     * 몬스터 컴포넌트를 반환하게 만듬
     */
    public Std_0812_Monster CreateMonster(string _name)
    {
        // 몬스터 리스트에서, 아무거나 비활성되 되어있는 경우 찾아서 스크립트 반환함
        Std_0812_Monster monsterScipt = monsterList.Find((o) => o.gameObject.activeSelf == false);
        if (monsterScipt != null)
        {
            monsterScipt.gameObject.SetActive(true);
            return monsterScipt;
        }
        else
        {
            int pos = _name.IndexOf('_');
            string rcName = _name.Substring(0, pos);    // 이걸 이렇게 쓸이유가있나
            //몬스터 리스트에 검색이 안되서 새로 생성해야 되는경우
            GameObject rcMonster = Resources.Load<GameObject>(rcName);   // 리소스폴더 최상위에 있다는 가정
            GameObject monsterObj = Instantiate<GameObject>(rcMonster);
            Std_0812_Monster newMonster = monsterObj.AddComponent<Std_0812_Monster>();
            monsterList.Add(newMonster);
            return newMonster;
        }
    }

    public void DeActiveMonster(string _name)
    {
        Std_0812_Monster monsterScript = monsterList.Find(o => o.gameObject.name.Equals(_name) &&
                                                               o.gameObject.activeSelf == true);
        if (monsterScript != null)
        {
            monsterScript.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //스페이스 누르면 비활성화
            DeActiveMonster($"TrollGiant_{Random.Range(0,10)}");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            //c누르면 생성
            Std_0812_Monster monsterScript = CreateMonster($"TrollGiant_{Random.Range(0,10)}");
            //생성한 몬스터의 이름과 위치를 변경(위치는 랜덤)
            //monsterScript.gameObject.name = "Monster";
            monsterScript.gameObject.name = "TrollGiant_" + Random.Range(0, 10).ToString(); //이렇게 이름을 2중으로 생성하는거 비효율
            monsterScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
    }
}
