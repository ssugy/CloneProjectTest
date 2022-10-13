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
            // key가 존재하면, key에 해당하는 TValue리스트에 값을 추가한다.
            dic[key].Add(val);
        }
        else
        {
            Debug.Log("2");
            // key가 존재하지 않으면, 우선 리스트부터 만들어주고, 값을 추가한다.
            list = new List<TValue>();
            list.Add(val);
            dic.Add(key, list);
        }
    }

    public List<TValue> GetData(TKey key)
    {
        List<TValue> list;
        //return dic[key];// 이렇게 하면 null을 반환하는게 키없다는 익셉션 발생시킨다.

        if (dic.TryGetValue(key, out list))
        {
            Debug.Log("3");
            // 키값이 있으면, 해당하는 리스트를 반환한다.
            return list;
        }
        else
        {
            // 키값이 없으면, null을 리턴한다.(값이 없으니까)
            Debug.Log("1");
            return null;
        }
    }
}
