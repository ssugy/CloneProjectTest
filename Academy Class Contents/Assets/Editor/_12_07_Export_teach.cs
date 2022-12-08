using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class _12_07_Export_teach
{
    static Dictionary<string, int> saveList = new Dictionary<string, int>();
    static Dictionary<int, GameObject> loadList = new Dictionary<int, GameObject>();
    // "Export/MapExport"�� �������� ��� MapExport�Լ��� ȣ��ȴ�.
    [MenuItem("Export/MapExport_Teach")]
    static public void MapExport()
    {
        // 3. ���� �ִ� Building�̶�� �̸��� �±׸� ���� ���ӿ�����Ʈ�� ���� ������Ʈ�� �ƴ� ��쿡 ���Ͽ� �����Ҽ�
        // �ֵ��� ���α׷� �ڵ带 �����Ͻÿ�. �����ϴ� �����Ϳ��� �̸�,�θ��ε���,��ġ,ȸ��,������ ������ ����.
        string sceneName = SceneManager.GetActiveScene().name;
        using(StreamWriter sr = new StreamWriter(Application.dataPath + "/" + sceneName + ".csv"))
        {
            GameObject [] buildings = GameObject.FindGameObjectsWithTag("Building");
            sr.WriteLine("index,name,parentIndex, posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");
            string lineData = string.Empty;
            for (int i = 0; i < buildings.Length; i++)
            {
                lineData = string.Empty;
                lineData += (i + 1).ToString();
                lineData += ",";
                lineData += buildings[i].name;
                lineData += ",";
                if (buildings[i].transform.parent.gameObject.name == "TerrainObject")
                {
                    lineData += "-1";
                }
                else
                {
                    // �θ���ӿ�����Ʈ�� �ε����� �˻��Ѵ�.
                    GameObject parentObj = buildings[i].transform.parent.gameObject;
                    lineData += saveList[parentObj.name].ToString();
                }
                lineData += ",";
                lineData += buildings[i].transform.localPosition.x.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localPosition.y.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localPosition.z.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localEulerAngles.x.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localEulerAngles.y.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localEulerAngles.z.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localScale.x.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localScale.y.ToString();
                lineData += ",";
                lineData += buildings[i].transform.localScale.z.ToString();
                sr.WriteLine(lineData);
                saveList.Add(buildings[i].name, (i + 1));
            }
            sr.Close();
            saveList.Clear();
        }
    }

    [MenuItem("Load/MapLoad_Teach")]
    static public void MapLoad()
    {
        loadList.Clear();
        GameObject terrainParent = GameObject.Find("TerrainObject");
        if (terrainParent == null)
        {
            terrainParent = new GameObject("TerrainObject");
            terrainParent.transform.position = Vector3.zero;
        }
        // 1. ��θ� ����
        // 2. ���� ���� �г��� �̿��ؼ� ������ ������ �� �ֵ���
        string path = Application.dataPath + "/" + SceneManager.GetActiveScene().name + ".csv";
        using( StreamReader sr = new StreamReader(path))
        {
            string lineData = string.Empty;
            lineData = sr.ReadLine();
            while ((lineData = sr.ReadLine()) != null)
            {
                string[] datas = lineData.Split(',');
                int index = int.Parse(datas[0]);
                string name = datas[1];
                int parentIndex = int.Parse(datas[2]);
                float xPos = float.Parse(datas[3]);
                float yPos = float.Parse(datas[4]);
                float zPos = float.Parse(datas[5]);
                float xRot = float.Parse(datas[6]);
                float yRot = float.Parse(datas[7]);
                float zRot = float.Parse(datas[8]);
                float xScale = float.Parse(datas[9]);
                float yScale = float.Parse(datas[10]);
                float zScale = float.Parse(datas[11]);
                // ���ҽ� �̸�
                int pos = name.IndexOf('_');
                string prefabName = name.Substring(0, pos);
                prefabName = prefabName.Trim();
                GameObject rcPreFab = Resources.Load<GameObject>(prefabName);
                GameObject obj = GameObject.Instantiate<GameObject>(rcPreFab);
                obj.name = name;
                //�θ� �����Ұ��� �׷��� ���� ��� ����
                if (parentIndex == -1)
                {
                    obj.transform.SetParent(terrainParent.transform);
                }
                else
                {
                    obj.transform.SetParent(loadList[parentIndex].transform);
                }
                obj.transform.localPosition = new Vector3(xPos, yPos, zPos);
                obj.transform.localEulerAngles = new Vector3(xRot, yRot, zRot);
                obj.transform.localScale = new Vector3(xScale, yScale, zScale);
                loadList.Add(index,obj);
            }
            sr.Close();
        }
    }
}

