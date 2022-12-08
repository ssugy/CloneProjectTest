using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

// 메뉴를 누르면 현재 씬 이름의 csv파일 생성
public class _12_07_Export : MonoBehaviour
{
    // 여기기능은 완성안됨
    static Dictionary<string, int> saveList = new Dictionary<string, int>();
    [MenuItem("Export/MapExportMe")]
    public static void MapExport()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + sceneName + ".csv"))
        {
            GameObject[] building = GameObject.FindGameObjectsWithTag("Building");
            // 게임오브젝트인덱스, 이름, 부모인덱스(상속관계표시, 부모없으면-1),위치xyz,회전xyz,스케일xyz
            sr.WriteLine("index,name,parentIndex,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");
            for (int i = 0; i < building.Length; i++)
            {
                int parentIndex = 0;
                Transform tr = null;
                
                //강사님 코드가 노가다가 너무 많아서 스크립트 복사해서 넣겠음.
                sr.Write($"{i},{building[i].name},{parentIndex}" +
                    $",{building[i].transform.position.x},{building[i].transform.position.y},{building[i].transform.position.z}" +
                    $",{building[i].transform.rotation.x},{building[i].transform.rotation.y},{building[i].transform.rotation.z}" +
                    $",{building[i].transform.localScale.x},{building[i].transform.localScale.y},{building[i].transform.localScale.z}\n");
            }
            sr.Close();
        }
    }

    // 여기는 완성됨
    [MenuItem("Load/MapLoad")]
    static public void MapLoad()
    {
        // 0. TerrainObject가 존재하는지 확인
        GameObject terrainParent = GameObject.Find("TerrainObject");
        if (terrainParent == null)
        {
            terrainParent = new GameObject("TerrainObject");
            terrainParent.transform.position = Vector3.zero;
        }

        // 1. 경로를 지정
        // 2. 파일 열기 패널을 이용해서 파일을 선택할 수 있도록
        string path = $"{Application.dataPath}/Resources/1207/";
        using (StreamReader sr = new StreamReader(path))
        {
            string lineData = string.Empty;
            while ((lineData = sr.ReadLine()) != null)
            {
                string[] datas = lineData.Split(',');
                int index = int.Parse(datas[0]);
                string name = datas[1];
                int parentIndex = int.Parse(datas[2]);
                Vector3 pos = new Vector3(float.Parse(datas[3]), float.Parse(datas[4]), float.Parse(datas[5]));
                Vector3 rot = new Vector3(float.Parse(datas[6]), float.Parse(datas[7]), float.Parse(datas[8]));
                Vector3 scale = new Vector3(float.Parse(datas[9]), float.Parse(datas[10]), float.Parse(datas[11]));

                // 리소스 이름을 어떻게 처리하느냐도 중요한 이슈
                string prefabName = "1207/Cube";
                GameObject rcPrefab = Resources.Load<GameObject>(prefabName);
                GameObject obj = GameObject.Instantiate(rcPrefab);
            }
        }
    }
}
