using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Std_Multimap<TKey, TValue> : MonoBehaviour
{
    public Dictionary<TKey, List<TValue>> dic;
    public Std_Multimap()
    {
        dic = new Dictionary<TKey, List<TValue>>();
    }

    public void Add(TKey key, TValue val)
    {
        List<TValue> list;
        if (dic.TryGetValue(key, out list))
        {
            Debug.Log("1");
            // key�� �����ϸ�, key�� �ش��ϴ� TValue����Ʈ�� ���� �߰��Ѵ�.
            dic[key].Add(val);
        }
        else
        {
            Debug.Log("2");
            // key�� �������� ������, �켱 ����Ʈ���� ������ְ�, ���� �߰��Ѵ�.
            list = new List<TValue>();
            list.Add(val);
            dic.Add(key, list);
        }
    }

    public List<TValue> GetData(TKey key)
    {
        List<TValue> list;
        //return dic[key];// �̷��� �ϸ� null�� ��ȯ�ϴ°� Ű���ٴ� �ͼ��� �߻���Ų��.

        if (dic.TryGetValue(key, out list))
        {
            Debug.Log("3");
            // Ű���� ������, �ش��ϴ� ����Ʈ�� ��ȯ�Ѵ�.
            return list;
        }
        else
        {
            // Ű���� ������, null�� �����Ѵ�.(���� �����ϱ�)
            Debug.Log("1");
            return null;
        }
    }
}
