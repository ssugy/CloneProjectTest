using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_2_ObjectPooling : MonoBehaviour
{
    List<_9_2_Monster> monsterList;
    private void Awake()
    {
        monsterList = new List<_9_2_Monster>();
        // 활성화된 게임오브젝트만 존재하는 리스트와 비활성화된 게임오브젝트만 존재하는 리스트를 동시에 사용하여 관리할 수 있다.
    }
    // Start is called before the first frame update
    void Start()
    {
        string name = string.Empty;
        for (int i = 0; i < 10; i++)
        {
            name = "TrollGiant_" + i.ToString();
            _9_2_Monster monsterScript = CreateMonster(name);
            // 생성한 몬스터의 이름과 위치를 변경(위치는 랜덤)
            monsterScript.gameObject.name = "TrollGiant_" + i.ToString();
            monsterScript.transform.position = new Vector3( Random.Range(-3, 3), 
                                                            Random.Range(-3, 3), 
                                                            Random.Range(-3, 3));
        }
    }
    public _9_2_Monster CreateMonster(string _name)
    {
        // 리스트에서 생성하고자 하는 게임오브젝트와 이름이 동일한 게임오브젝트와 비활성화된 게임오브젝트를 검색
        _9_2_Monster monsterScript = monsterList.Find(o => (o.gameObject.activeSelf == false));
        // 사용할 수 있는 비활성화된 몬스터가 존재
        if( monsterScript != null )
        {
            monsterScript.gameObject.SetActive(true);
            return monsterScript;
        }
        else
        {
            int pos = _name.IndexOf("_");
            string rcName = _name.Substring(0, _name.Length - (_name.Length - pos));
            // 새로 생성해야 하는 경우
            GameObject rcMonster = Resources.Load<GameObject>(rcName);   // 본인의 ResourceManager 클래스를 사용하여 필요한 리소스 로드
            GameObject monsterObj = Instantiate<GameObject>(rcMonster);
            _9_2_Monster newMonster = monsterObj.AddComponent<_9_2_Monster>();
            monsterList.Add(newMonster);
            return newMonster;
        }
    }
    public void DisableMonster(string _name)
    {
        _9_2_Monster monsterScript = monsterList.Find(o => ( o.gameObject.name.Equals(_name) &&
                                                             o.gameObject.activeSelf == true));
        if( monsterScript!=null )
            monsterScript.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            string name = "TrollGiant_" + Random.Range(0, 10).ToString();
            DisableMonster(name);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            string name = "TrollGiant_" + Random.Range(0, 10).ToString();
            _9_2_Monster monsterScript = CreateMonster(name);
            // 생성한 몬스터의 이름과 위치를 변경(위치는 랜덤)
            monsterScript.gameObject.name = "TrollGiant_" + Random.Range(0, 10).ToString();
            monsterScript.transform.position = new Vector3(Random.Range(-3, 3),
                                                            Random.Range(-3, 3),
                                                            Random.Range(-3, 3));
        }
    }
}
