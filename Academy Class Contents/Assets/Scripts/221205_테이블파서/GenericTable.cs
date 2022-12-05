using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTable<T> where T: class
{
    private T t;        // �̰� ��ü��. Monster, Character, Npc..���
    public T data { get; set; }
    
    // 1. ������ ó��
    public GenericTable() { }
    public GenericTable(T _t) { t = _t; }
    
    // 2. ����� �Լ� ó��
    public T LoadData() { return t; }
    public void SaveData(T _t) { }

    // 3. �̷�����ΰ�
    //public T ShowTable<T>() {}
}
