using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;

public class Std_SaveMonsterData
{
    [MenuItem("Save/Monster")]
    static void DoSomething()
    {
        // �޴�â�� ���� ����� �װ� ������ �� ����ǰ� ��.
        Debug.Log("DoSomething ����");
    }

    /**
     * ����1: Export�޴��� SceneData�� ������, ���� �� �̸�.txt���� �����ϱ�
     */
    [MenuItem("Export/SceneData")]
    static void ExportSceneData()
    {
        Scene scene = SceneManager.GetActiveScene();
        //string path = Application.dataPath + "/" + scene.name + ".txt"; 
        string path = "c://test.txt"; // �̷��� ����Ƽ �ܺ� ������ �����Ϸ��� ������ ���ٰ� ���. ������ �ְ�, ����Ƽ �������� ������ ��� �������� �����ϸ�ɵ�.
        using (StreamWriter sw = new StreamWriter(path))    // ���� ������ ������.
        {
            // ����2 : Ȯ���ڸ� csv�� �����Ͻÿ� - �̰� ���� csv�� ������ �ǹ�
            // ���� �� ������ ���� ������ �����ϴ� ���̸� �Ʒ��� �ڵ� ���
            string result = Path.ChangeExtension(path, ".xlsx");    // �̰Ŵ� ��Ȯ�ϰԴ� �ٲ� ���ϸ��� ���Ե� Ǯ ����̴�.
            Debug.Log(result);
            File.Move(path, result);    // �̰� ���� �������̶� �ȵ�. ���� ����Ƽ �����Ͱ� ������̱� ������, �����ͻ󿡼� ��ü ���� ������ �ȵ� �� ����
            sw.Close();
        }
    }

    /**
     * csv���Ͽ� ���� �÷��� ��� ���ӿ��������� �̸�, ��ġ ������� �����͸� �����Ͻÿ�
     * ���� �÷��� ��� ���ӿ�����Ʈ�� �˻� ��� : �±׸� �̿��� �˻�
     */
    [MenuItem("Export/exam3")]
    static void SaveSceneData()
    {
        Scene scene = SceneManager.GetActiveScene();
        string path = Application.dataPath + "/" + scene.name + ".csv"; 
        using (StreamWriter sw = new StreamWriter(path))    // ���� ������ ������.
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("myTag"); // ������ �±��� �����۸� ������.
            //GameObject[] allList = GameObject.FindObjectsOfType<GameObject>();  // �̷��� �ϸ� �±׻������ ��� ���ӿ�����Ʈ �����´�.
            foreach (GameObject item in list)
            {
                sw.WriteLine($"{item.name}" +
                            $",{item.transform.position.x}" +
                            $",{item.transform.position.y}" +
                            $",{item.transform.position.z}");
            }
            sw.Close();
        }
    }

    [MenuItem("Export/exam4")]
    static void ImportSceneData()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string path = Application.dataPath + "/" + currentScene.name + ".csv";
        string path = EditorUtility.OpenFilePanel("Ÿ��Ʋ", Application.dataPath, "csv");  // ���� ���� �г�
        using (StreamReader sr = new StreamReader(path))
        {
            string line = string.Empty;
            line = sr.ReadLine();   //�÷����� ����
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log("*** �ٵ����� ***");
                string[] datas = line.Split(',');
                Vector3 pos = new Vector3(float.Parse(datas[1]), float.Parse(datas[2]), float.Parse(datas[3]));

                GameObject tmpRc = Resources.Load<GameObject>(datas[0]);
                GameObject obj = GameObject.Instantiate<GameObject>(tmpRc, pos, Quaternion.identity);
                obj.name = datas[0];
            }
        }
    }
}
