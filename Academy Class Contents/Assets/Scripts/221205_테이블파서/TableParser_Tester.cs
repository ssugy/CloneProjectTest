using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TableParser_Tester : MonoBehaviour
{
    string path;
    string path2;
    void Start()
    {
        path = $"{Application.dataPath}/Scripts/221205_���̺��ļ�/test.csv";
        path2 = $"{Application.dataPath}/Scripts/221205_���̺��ļ�/test2.csv";

        MonsterTable.instance.LoadData(path);
        MonsterTable.instance.LoadData(path2);  // ���̺��� �������� �ϳ��� ���� ����. �̱����̴ϱ�.
        foreach (MonsterData item in MonsterTable.instance.LIST)
        {
            Debug.Log(item.index);
            Debug.Log(item.name);
            Debug.Log(item.str);
        }

        Debug.Log("�������̺� ����Ʈ ī��Ʈ : " + MonsterTable.instance.LIST.Count);   // �̰� ���̺��� �� �������� �˷��ִ� �ڵ�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // �޸� üũ - ������ �ڵ� Ȯ�ο�
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

                UnityEditor.EditorApplication.isPlaying = false;    // ������ ���߱�
            }
        }
    }
}

