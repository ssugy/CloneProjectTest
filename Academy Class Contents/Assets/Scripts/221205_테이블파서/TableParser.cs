using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// ����Ʈ�� �����ϴ� ����ü
public struct MonsterData
{
    public int index;
    public string name;
    public float str;
}
public struct NpcData
{
    public int index;
    public string name;
    public byte type;
}

// T�� �̱����� ���� T
// Q�� ����Ʈ�� �����ϱ� ���� Q
// �������� : T�� Ŭ���������ϰ�, �Ű��������� ������ �ʿ�(new), Q�� ����ü
public class TableParser<T, Q> where T : class, new() where Q : struct
{
    protected List<Q> list;
    public List<Q> LIST
    {
        get { return list; }
    }
    private static T inst;
    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
    public TableParser()
    {

    }
    public void LoadData(string _fileName)
    {
        list = new List<Q>();
        using (StreamReader sr = new StreamReader(_fileName))
        {
            string line = string.Empty;
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] datas = line.Split(',');
                ReadData(datas);
            }
            sr.Close();
        }
    }

    // �ش��Լ��� �ڽİ�ü���� LoadData�� ȣ���ϸ� �ڽ� ReadData�� ȣ��ȴ�.
    virtual public void ReadData(string[] _datas)
    {
    }
}


public class MonsterTable : TableParser<MonsterTable, MonsterData>
{

    public override void ReadData(string[] _datas)
    {
        MonsterData tmp;
        tmp.index = int.Parse(_datas[0]);
        tmp.name = _datas[1];
        tmp.str = float.Parse(_datas[2]);
        list.Add(tmp);
    }
}

public class NpcTable : TableParser<NpcTable, NpcData>
{
    public override void ReadData(string[] _datas)
    {
        NpcData tmp;
        tmp.index = int.Parse(_datas[0]);
        tmp.name = _datas[1];
        tmp.type = byte.Parse(_datas[2]);
        list.Add(tmp);
    }
}
