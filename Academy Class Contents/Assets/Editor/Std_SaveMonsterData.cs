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
        // 메뉴창이 새로 생기고 그거 눌렀을 때 실행되게 함.
        Debug.Log("DoSomething 실행");
    }

    /**
     * 문제1: Export메뉴에 SceneData를 누르면, 현재 씬 이름.txt파일 생성하기
     */
    [MenuItem("Export/SceneData")]
    static void ExportSceneData()
    {
        Scene scene = SceneManager.GetActiveScene();
        //string path = Application.dataPath + "/" + scene.name + ".txt"; 
        string path = "c://test.txt"; // 이렇게 유니티 외부 파일을 변경하려면 권한이 없다고 뜬다. 권한은 있고, 유니티 에디터의 범위를 벗어난 공간으로 지정하면될듯.
        using (StreamWriter sw = new StreamWriter(path))    // 파일 없으면 생성함.
        {
            // 문제2 : 확장자를 csv로 변경하시오 - 이거 새로 csv로 만들라는 의미
            // 만약 이 문제를 기존 파일을 변경하는 것이면 아래의 코드 사용
            string result = Path.ChangeExtension(path, ".xlsx");    // 이거는 정확하게는 바뀔 파일명이 포함된 풀 경로이다.
            Debug.Log(result);
            File.Move(path, result);    // 이거 파일 점유중이라서 안됨. 실제 유니티 에디터가 사용중이기 때문에, 에디터상에서 자체 파일 변경은 안될 것 같다
            sw.Close();
        }
    }

    /**
     * csv파일에 씬에 올려진 모든 게임오브제그의 이름, 위치 순서대로 데이터를 저장하시오
     * 씬에 올려진 모든 게임오브젝트의 검색 방법 : 태그를 이용한 검색
     */
    [MenuItem("Export/exam3")]
    static void SaveSceneData()
    {
        Scene scene = SceneManager.GetActiveScene();
        string path = Application.dataPath + "/" + scene.name + ".csv"; 
        using (StreamWriter sw = new StreamWriter(path))    // 파일 없으면 생성함.
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("myTag"); // 선정된 태그의 아이템만 가져옴.
            //GameObject[] allList = GameObject.FindObjectsOfType<GameObject>();  // 이렇게 하면 태그상관없이 모든 게임오브젝트 가져온다.
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
        string path = EditorUtility.OpenFilePanel("타이틀", Application.dataPath, "csv");  // 파일 열기 패널
        using (StreamReader sr = new StreamReader(path))
        {
            string line = string.Empty;
            line = sr.ReadLine();   //컬럼명을 읽음
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log("*** 줄데이터 ***");
                string[] datas = line.Split(',');
                Vector3 pos = new Vector3(float.Parse(datas[1]), float.Parse(datas[2]), float.Parse(datas[3]));

                GameObject tmpRc = Resources.Load<GameObject>(datas[0]);
                GameObject obj = GameObject.Instantiate<GameObject>(tmpRc, pos, Quaternion.identity);
                obj.name = datas[0];
            }
        }
    }
}
