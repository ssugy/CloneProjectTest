using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoadExample_8_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �ε�� �޸𸮿� �÷������� �ǹ�
        // ȭ�鿡 �������� ���� �ƴϴ�.
        GameObject tmp = Resources.Load("Character/Meshtint Free Knight") as GameObject;
        // ���� �ν��Ͻ�����
        GameObject obj = GameObject.Instantiate(tmp, new Vector3(3,3,3), Quaternion.identity);
        obj.name = "Meshtint Free Knight";
        //
        // Weapon������ �����ϴ� ��� �ֻ��� �ε�
        GameObject [] weapons = Resources.LoadAll<GameObject>("Weapon/");
        // �ε��� ���ӿ�����Ʈ�� �ν��Ͻ��� ���� ����
        foreach(GameObject one in weapons)
        {
            GameObject weapon = GameObject.Instantiate<GameObject>(one);
            weapon.name = one.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
