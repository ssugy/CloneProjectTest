using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_ObjectPooling : MonoBehaviour
{
    List<Std_0812_Monster> monsterList;

    private void Awake()
    {
        monsterList = new List<Std_0812_Monster>();
        // Ȱ��ȭ�� ���ӿ�����Ʈ�� �����ϴ� ����Ʈ�� ��Ȱ��ȭ�� ���� ������Ʈ�� �����ϴ� ����Ʈ�� ���ÿ� ����Ͽ� ���� �� �� �ִ�.
    }

    private void Start()
    {
        // 10���� ����
        for (int i = 0; i < 10; i++)
        {
            Std_0812_Monster monsterScript = CreateMonster("TrollGiant_");
            //������ ������ �̸��� ��ġ�� ����(��ġ�� ����)
            monsterScript.gameObject.name = $"TrollGiant_{i}";
            monsterScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
    }

    /**
     * ������Ʈ Ǯ���� ���ӿ�����Ʈ�� ��ȯ���� �ʰ�, 
     * ���� ������Ʈ�� ��ȯ�ϰ� ����
     */
    public Std_0812_Monster CreateMonster(string _name)
    {
        // ���� ����Ʈ����, �ƹ��ų� ��Ȱ���� �Ǿ��ִ� ��� ã�Ƽ� ��ũ��Ʈ ��ȯ��
        Std_0812_Monster monsterScipt = monsterList.Find((o) => o.gameObject.activeSelf == false);
        if (monsterScipt != null)
        {
            monsterScipt.gameObject.SetActive(true);
            return monsterScipt;
        }
        else
        {
            int pos = _name.IndexOf('_');
            string rcName = _name.Substring(0, pos);    // �̰� �̷��� ���������ֳ�
            //���� ����Ʈ�� �˻��� �ȵǼ� ���� �����ؾ� �Ǵ°��
            GameObject rcMonster = Resources.Load<GameObject>(rcName);   // ���ҽ����� �ֻ����� �ִٴ� ����
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
            //�����̽� ������ ��Ȱ��ȭ
            DeActiveMonster($"TrollGiant_{Random.Range(0,10)}");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            //c������ ����
            Std_0812_Monster monsterScript = CreateMonster($"TrollGiant_{Random.Range(0,10)}");
            //������ ������ �̸��� ��ġ�� ����(��ġ�� ����)
            //monsterScript.gameObject.name = "Monster";
            monsterScript.gameObject.name = "TrollGiant_" + Random.Range(0, 10).ToString(); //�̷��� �̸��� 2������ �����ϴ°� ��ȿ��
            monsterScript.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        }
    }
}
