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
            // 1. 개념상 csv파일 내부에 최상단에 들어가야되는 내용은 코드상에서도 가장 위에 적어주는 것이 이해하기 좋을 것 같습니다.
            sw.WriteLine("index,name,parentIndex,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");  
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
            Array.ForEach(objs, e =>
            {
                // 부모가 없는 최상위 오브젝트들만의 리스트를 만듬.
                if (e.transform.parent == null)
                {
                    sw.WriteLine($"{++index},{e.name},{-1}" +
                        $",{e.transform.position.x},{e.transform.position.y},{e.transform.position.z}" +
                        $",{e.transform.rotation.x},{e.transform.rotation.y},{e.transform.rotation.z}" +
                        $",{e.transform.localScale.x},{e.transform.localScale.y},{e.transform.localScale.z}");

                    int parentIndex = index;
                    // 자식객체를 파악하기 위한 재귀함수 실행
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
        // 추가적인 자식이 없으면 여기까지 작성하고 종료
        _sw.WriteLine($"{++index},{_obj.name},{_parent}" +
            $",{_obj.transform.position.x},{_obj.transform.position.y},{_obj.transform.position.z}" +
            $",{_obj.transform.rotation.x},{_obj.transform.rotation.y},{_obj.transform.rotation.z}" +
            $",{_obj.transform.localScale.x},{_obj.transform.localScale.y},{_obj.transform.localScale.z}");
       
        // 추가적인 자식이 있으면 자신의 정보를 먼저 입력한 다음 재귀호출.
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
