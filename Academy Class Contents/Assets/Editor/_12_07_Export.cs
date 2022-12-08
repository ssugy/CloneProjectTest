using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

// �޴��� ������ ���� �� �̸��� csv���� ����
public class _12_07_Export : MonoBehaviour
{
    // �������� �ϼ��ȵ�
    static Dictionary<string, int> saveList = new Dictionary<string, int>();
    [MenuItem("Export/MapExportMe")]
    public static void MapExport()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        using (StreamWriter sr = new StreamWriter(Application.dataPath + "/" + sceneName + ".csv"))
        {
            GameObject[] building = GameObject.FindGameObjectsWithTag("Building");
            // ���ӿ�����Ʈ�ε���, �̸�, �θ��ε���(��Ӱ���ǥ��, �θ������-1),��ġxyz,ȸ��xyz,������xyz
            sr.WriteLine("index,name,parentIndex,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");
            for (int i = 0; i < building.Length; i++)
            {
                int parentIndex = 0;
                Transform tr = null;
                
                //����� �ڵ尡 �밡�ٰ� �ʹ� ���Ƽ� ��ũ��Ʈ �����ؼ� �ְ���.
                sr.Write($"{i},{building[i].name},{parentIndex}" +
                    $",{building[i].transform.position.x},{building[i].transform.position.y},{building[i].transform.position.z}" +
                    $",{building[i].transform.rotation.x},{building[i].transform.rotation.y},{building[i].transform.rotation.z}" +
                    $",{building[i].transform.localScale.x},{building[i].transform.localScale.y},{building[i].transform.localScale.z}\n");
            }
            sr.Close();
        }
    }

    // ����� �ϼ���
    [MenuItem("Load/MapLoad")]
    static public void MapLoad()
    {
        // 0. TerrainObject�� �����ϴ��� Ȯ��
        GameObject terrainParent = GameObject.Find("TerrainObject");
        if (terrainParent == null)
        {
            terrainParent = new GameObject("TerrainObject");
            terrainParent.transform.position = Vector3.zero;
        }

        // 1. ��θ� ����
        // 2. ���� ���� �г��� �̿��ؼ� ������ ������ �� �ֵ���
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

                // ���ҽ� �̸��� ��� ó���ϴ��ĵ� �߿��� �̽�
                string prefabName = "1207/Cube";
                GameObject rcPrefab = Resources.Load<GameObject>(prefabName);
                GameObject obj = GameObject.Instantiate(rcPrefab);
            }
        }
    }
}
