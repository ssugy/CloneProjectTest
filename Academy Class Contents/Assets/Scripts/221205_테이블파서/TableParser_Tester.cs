using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TableParser_Tester : MonoBehaviour
{
    string path;
    string path2;
    void Start()
    {
        path = $"{Application.dataPath}/Scripts/221205_테이블파서/test.csv";
        path2 = $"{Application.dataPath}/Scripts/221205_테이블파서/test2.csv";

        MonsterTable.instance.LoadData(path);
        MonsterTable.instance.LoadData(path2);  // 테이블은 종류별로 하나만 저장 가능. 싱글톤이니까.
        foreach (MonsterData item in MonsterTable.instance.LIST)
        {
            Debug.Log(item.index);
            Debug.Log(item.name);
            Debug.Log(item.str);
        }

        Debug.Log("몬스터테이블 리스트 카운트 : " + MonsterTable.instance.LIST.Count);   // 이건 테이블이 몇 줄인지를 알려주는 코드
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 메모리 체크 - 주혁씨 코드 확인용
            for (int i = 0; i < 100; i++)
            {
                //List<CharacterData> list = TableParser_JY<CharacterData>.TableParsing(path);

                //CharacterData charData = new CharacterData();
                //List<CharacterData> list3 = TableParser_JY<CharacterData>.TableParsing(path2);
                //List<MonsterData> list2 = TableParser_JY<MonsterData>.TableParsing(path2);
                //foreach (var item in list)
                //{
                //    Debug.Log(item.index);
                //    Debug.Log(item.name);
                //    Debug.Log(item.level);
                //}

                UnityEditor.EditorApplication.isPlaying = false;    // 에디터 멈추기
            }
        }
    }
}

