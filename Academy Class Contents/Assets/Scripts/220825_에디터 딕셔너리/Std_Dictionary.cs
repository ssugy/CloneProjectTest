using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Dictionary : MonoBehaviour
{
    // Ű�� �����ϰ� ���� ���ڿ��� �ϴ� ��ųʸ� ����
    Dictionary<int, string> dict;
    private void Awake()
    {
        dict = new Dictionary<int, string>();
    }

    private void Start()
    {
        dict.Add(0, "�̽¿�");
        dict.Add(1, "����ȣ");
        dict.Add(2, "��ȿ��");
        // 1. Ű�� �̿��Ͽ� ���� ���
        string result;
        if (dict.TryGetValue(0, out result))
        {
            // 0�� �ش��ϴ� ��
            Debug.Log(result);
        }
        //
    }
}
