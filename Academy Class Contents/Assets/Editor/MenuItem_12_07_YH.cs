using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text.RegularExpressions;
using UnityEditor;

public class MenuItem_12_07_YH
{
    static int index;
    [UnityEditor.MenuItem("Export/MapExportYH")]
    public static void MapExport()
    {
        index = 0;
        string filePath = $"{Application.dataPath}/Resources/{SceneManager.GetActiveScene().name}.csv";
        using (StreamWriter sw = new(filePath))
        {
            // 1. ����� csv���� ���ο� �ֻ�ܿ� ���ߵǴ� ������ �ڵ�󿡼��� ���� ���� �����ִ� ���� �����ϱ� ���� �� �����ϴ�.
            sw.WriteLine("index,name,parentIndex,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");  
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
            Array.ForEach(objs, e =>
            {
                // �θ� ���� �ֻ��� ������Ʈ�鸸�� ����Ʈ�� ����.
                if (e.transform.parent == null)
                {
                    sw.WriteLine($"{++index},{e.name},{-1}" +
                        $",{e.transform.position.x},{e.transform.position.y},{e.transform.position.z}" +
                        $",{e.transform.rotation.x},{e.transform.rotation.y},{e.transform.rotation.z}" +
                        $",{e.transform.localScale.x},{e.transform.localScale.y},{e.transform.localScale.z}");

                    int parentIndex = index;
                    // �ڽİ�ü�� �ľ��ϱ� ���� ����Լ� ����
                    for (int i = 0; i < e.transform.childCount; i++)
                    {
                        WriteChild(e.transform.GetChild(i).gameObject, sw, parentIndex);
                    }
                }
            });
            sw.Close();
        }
    }

    public static void WriteChild(GameObject _obj, StreamWriter _sw, int _parent)
    {
        // �߰����� �ڽ��� ������ ������� �ۼ��ϰ� ����
        _sw.WriteLine($"{++index},{_obj.name},{_parent}" +
            $",{_obj.transform.position.x},{_obj.transform.position.y},{_obj.transform.position.z}" +
            $",{_obj.transform.rotation.x},{_obj.transform.rotation.y},{_obj.transform.rotation.z}" +
            $",{_obj.transform.localScale.x},{_obj.transform.localScale.y},{_obj.transform.localScale.z}");
       
        // �߰����� �ڽ��� ������ �ڽ��� ������ ���� �Է��� ���� ���ȣ��.
        if (_obj.transform.childCount > 0)
        {
            int parentIndex = index;
            for (int i = 0; i < _obj.transform.childCount; i++)
            {
                WriteChild(_obj.transform.GetChild(i).gameObject, _sw, parentIndex);
            }
        }
    }
}
