using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Std_Exam0830 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string path = Application.dataPath + "/Save/" + "test.txt";
        //Debug.Log(path);

        //string dataPath = Application.dataPath + "/" + "test.csv";
        //GameObject go = GameObject.Find("obj");
        //string objName = go.name;
        //Vector3 objPos = go.transform.position;
        //using (StreamWriter sw = new StreamWriter(dataPath))
        //{
        //    sw.WriteLine($"{objName},{objPos.x},{objPos.y},{objPos.z}");
        //    sw.Close();
        //}

        ////����1�� : ���ڿ��� �����͸� ����Ʈ �迭�� ����
        //string str = "�ӽñ���123";
        //byte[] buffer = new byte[str.Length];
        //buffer = Encoding.Unicode.GetBytes(str);

        ////����2�� : �迭�� �����͸� ���ڿ��� ����
        //string afterStr = Encoding.Unicode.GetString(buffer);
        //Debug.Log(afterStr);

        //GameObject go = GameObject.Find("obj");
        //transform.SetParent(go.transform);

        //string curDirectory = Directory.GetCurrentDirectory();
        //Debug.Log("���� ���丮 = " + curDirectory);
        //string[] subDirectory = Directory.GetDirectories(curDirectory);
        //foreach (string one in subDirectory)
        //{
        //    Debug.Log("���� ���丮 = " + one);
        //}

        string path = Application.dataPath + "/" + "test.csv";
        using (StreamReader sr = new StreamReader(path))
        {
            string[] strs = sr.ReadLine().Split(',');
            foreach (string item in strs)
            {
                int.Parse(item);    //������ ��ȯ
                float.Parse(item);  //�Ǽ��� ��ȯ
            }
            sr.Close();
        }

        //string str = "0123456789";
        //string str2 = str.Substring(1, 3);
        //Debug.Log(str2);

        //Dictionary<string, int> dic = new Dictionary<string, int>();
        //dic.Add("SCORE", 10);

        //PlayerPrefs.SetInt("SCORE", 10);
        //PlayerPrefs.SetString("Ű��", "������ ����Ʈ�����͸� string���� ��ȯ�� ��");

        //GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
        //string path = Application.dataPath + "/" + "objNames.txt";
        //using (StreamWriter sw = new StreamWriter(path))
        //{
        //    foreach (GameObject item in objs)
        //    {
        //        sw.WriteLine(item.name);
        //    }
        //    sw.Close();
        //}

        //string path2 = Application.dataPath + "/" + "objNames.txt";
        //using (StreamReader sr = new StreamReader(path2))
        //{
        //    while (sr.ReadLine() != null)
        //    {
        //        Debug.Log(sr.ReadLine());
        //    }
        //    sr.Close();
        //}

        //string path = Application.dataPath + "/" + "test.csv";
        //using (StreamReader sr = new StreamReader(path))
        //{
        //    while (sr.ReadLine() != null)
        //    {
        //        Debug.Log(sr.ReadLine());
        //    }
        //    sr.Close();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
