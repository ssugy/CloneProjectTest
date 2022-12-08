using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class MenuItem_12_07
{
    static int index = 0;
    // ����Ƽ �����Ϳ��� Export/MapExport �޴� �������� ������ ��� �ش� �Լ��� ȣ��ȴ�.
    [UnityEditor.MenuItem("Export/MapExport")]
    public static void MapExport()
    {
        string fileName = SceneManager.GetActiveScene().name + ".csv";
        string filePath = Application.dataPath + "/Resources/" + fileName;
        Debug.Log(fileName);
        using (StreamWriter sw = new(filePath))
        {            
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
            List<GameObject> parents = new();
            
            Array.ForEach(objs, e =>
            {
                // �θ� ���� �ֻ��� ������Ʈ�鸸�� ����Ʈ�� ����.
                if (e.transform.parent == null)
                {
                    parents.Add(e);
                }
            });

            parents.ForEach(e => Debug.Log(e.name));            

            sw.WriteLine("index,name,parentIndex,posx,posy,posz,rotx,roty,rotz," +
                "scalex,scaley,scalez");
            if (objs.Length >= 1)
            {
                index = 0;
                parents.ForEach(e =>
                {
                    // �θ� ���� �Է�.
                    string tmp = string.Empty;
                    tmp += ++index + ",";
                    tmp += e.name + ",";
                    tmp += "-1,";
                    tmp += Regex.Replace(e.transform.position.ToString(), "[()]", "") + ",";
                    tmp += Regex.Replace(e.transform.localEulerAngles.ToString(), "[()]", "") + ",";
                    tmp += Regex.Replace(e.transform.localScale.ToString(), "[()]", "");
                    sw.WriteLine(tmp);
                    int parentIndex = index;
                    for (int i = 0; i < e.transform.childCount; i++)
                    {
                        WriteChild(e.transform.GetChild(i).gameObject, sw, parentIndex);
                    }

                });
            }
            sw.Close();
        }
    }

    public static void WriteChild(GameObject _obj, StreamWriter _sw, int _parent)
    {
        // �ڽ��� ������.
        if (_obj.transform.childCount == 0)
        {            
            string tmp = string.Empty;
            tmp += ++index + ",";
            tmp += _obj.name + ",";
            tmp += _parent + ",";
            tmp += Regex.Replace(_obj.transform.position.ToString(), "[()]", "") + ",";
            tmp += Regex.Replace(_obj.transform.localEulerAngles.ToString(), "[()]", "") + ",";
            tmp += Regex.Replace(_obj.transform.localScale.ToString(), "[()]", "");
            _sw.WriteLine(tmp);
            return;
        }
        // �ڽ��� ������ �ڽ��� ������ ���� �Է��� ���� ���ȣ��.
        else
        {
            string tmp = string.Empty;
            tmp += ++index + ",";
            tmp += _obj.name + ",";
            tmp += _parent + ",";
            tmp += Regex.Replace(_obj.transform.position.ToString(), "[()]", "") + ",";
            tmp += Regex.Replace(_obj.transform.localEulerAngles.ToString(), "[()]", "") + ",";
            tmp += Regex.Replace(_obj.transform.localScale.ToString(), "[()]", "");
            _sw.WriteLine(tmp);
            int parentIndex = index;
            for (int i = 0; i < _obj.transform.childCount; i++)
            {
                WriteChild(_obj.transform.GetChild(i).gameObject, _sw, parentIndex);
            }
        }           
    }
}
