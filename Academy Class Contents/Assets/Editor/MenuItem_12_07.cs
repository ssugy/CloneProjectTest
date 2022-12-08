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
    // 유니티 에디터에서 Export/MapExport 메뉴 아이템을 선택할 경우 해당 함수가 호출된다.
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
                // 부모가 없는 최상위 오브젝트들만의 리스트를 만듦.
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
                    // 부모 정보 입력.
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
        // 자식이 없으면.
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
        // 자식이 있으면 자신의 정보를 먼저 입력한 다음 재귀호출.
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
