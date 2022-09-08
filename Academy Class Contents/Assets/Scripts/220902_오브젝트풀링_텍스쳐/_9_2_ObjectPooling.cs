using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_2_ObjectPooling : MonoBehaviour
{
    List<_9_2_Monster> monsterList;
    private void Awake()
    {
        monsterList = new List<_9_2_Monster>();
        // Ȱ��ȭ�� ���ӿ�����Ʈ�� �����ϴ� ����Ʈ�� ��Ȱ��ȭ�� ���ӿ�����Ʈ�� �����ϴ� ����Ʈ�� ���ÿ� ����Ͽ� ������ �� �ִ�.
    }
    // Start is called before the first frame update
    void Start()
    {
        string name = string.Empty;
        for (int i = 0; i < 10; i++)
        {
            name = "TrollGiant_" + i.ToString();
            _9_2_Monster monsterScript = CreateMonster(name);
            // ������ ������ �̸��� ��ġ�� ����(��ġ�� ����)
            monsterScript.gameObject.name = "TrollGiant_" + i.ToString();
            monsterScript.transform.position = new Vector3( Random.Range(-3, 3), 
                                                            Random.Range(-3, 3), 
                                                            Random.Range(-3, 3));
        }
    }
    public _9_2_Monster CreateMonster(string _name)
    {
        // ����Ʈ���� �����ϰ��� �ϴ� ���ӿ�����Ʈ�� �̸��� ������ ���ӿ�����Ʈ�� ��Ȱ��ȭ�� ���ӿ�����Ʈ�� �˻�
        _9_2_Monster monsterScript = monsterList.Find(o => (o.gameObject.activeSelf == false));
        // ����� �� �ִ� ��Ȱ��ȭ�� ���Ͱ� ����
        if( monsterScript != null )
        {
            monsterScript.gameObject.SetActive(true);
            return monsterScript;
        }
        else
        {
            int pos = _name.IndexOf("_");
            string rcName = _name.Substring(0, _name.Length - (_name.Length - pos));
            // ���� �����ؾ� �ϴ� ���
            GameObject rcMonster = Resources.Load<GameObject>(rcName);   // ������ ResourceManager Ŭ������ ����Ͽ� �ʿ��� ���ҽ� �ε�
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
            // ������ ������ �̸��� ��ġ�� ����(��ġ�� ����)
            monsterScript.gameObject.name = "TrollGiant_" + Random.Range(0, 10).ToString();
            monsterScript.transform.position = new Vector3(Random.Range(-3, 3),
                                                            Random.Range(-3, 3),
                                                            Random.Range(-3, 3));
        }
    }
}
