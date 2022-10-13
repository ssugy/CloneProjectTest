using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_1011Dictionary : MonoBehaviour
{
    // �Ϲ����� dictionary����
    Dictionary<int, int> dict1;

    /**
     * ��Ƽ��
     * Ű�� �ش��ϴ� ���� �������� ���
     * Ű�� �����ϴ�.(�Ϲ����� Dictionary�� ����)
     * Dictionary<Ű, ����Ʈ>
     */
    Dictionary<int, List<int>> dict2;    // Ű:����, ��:������ �����ϴ� ����Ʈ
    Dictionary<string, List<string>> dict3;    // Ű:���ڿ�, ��:���ڿ��� �����ϴ� ����Ʈ
    void Start()
    {
        dict1 = new Dictionary<int, int>();
        dict2 = new Dictionary<int, List<int>>();
        dict3 = new Dictionary<string, List<string>>();
        //�� ����
        dict1.Add(0, 100);
        dict1.Add(1, 102);

        // Ű�� �ش��ϴ� ���� ��� dic1[0]�̰Ŷ� ��������� Ű���� ���� �� �����Ѵٴ� �ǹ�
        int findValue;
        if (dict1.TryGetValue(0, out findValue))
        {
            // Ű�� �ش��ϴ� ���� �����ϴ� ��� findValue������ ���� ����
            //Debug.Log(findValue);
        }

        // ������ �̿��� ref�� out
        // ref�� �ʱ�ȭ �� �Լ��� �����ؾߵǰ�, out�� �ʱ�ȭ ������� �Լ��� ������ �� ������, out�� �����ϴ� �Լ������� ���� �־��ִ� ������ �־�� �ȴ�.
        int outData;
        TestOut(out outData);

        int refData = 100;
        TestRef(ref refData);

        // ��Ƽ�� Ŭ������ ����
        Std_Multimap<int,int> std = new Std_Multimap<int, int>();
        std.Add(0, 100);
        std.Add(0, 200);

        foreach (var item in std.GetData(0))
        {
            Debug.Log(item);
        }
    }

    private void TestOut(out int a)
    {
        a = 100;    //�̰� �־�ߵȴ�. �̰� ���ϸ� ������. ref�� �ֱ����� �ʱ�ȭ �ؾߵǰ�, out�� ���⿡ �ʱ�ȭ�ؾߵ�.
    }

    private void TestRef(ref int b)
    {

    }
}
