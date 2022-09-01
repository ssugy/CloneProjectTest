using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Std_DirectoryAndFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string curDirectory = Directory.GetCurrentDirectory();
        //Debug.Log($"현재 디렉토리 : {curDirectory}"); // 에셋 위의 프로젝트 폴더 경로가 나옴.
        //string[] subDirectory = Directory.GetDirectories(curDirectory);
        //foreach (string item in subDirectory)
        //{
        //    Debug.Log($"하위 디렉토리 : {item}");
        //}
        
        //string txtPath = $"{Application.dataPath}/sample.txt";
        //Debug.Log(txtPath);
        //using (StreamWriter sw = new StreamWriter(txtPath))
        //{
        //    string startPath = "D:/Work/Python";
        //    GetSubDirInfo(startPath, sw);
        //}

    }

    // D드라이브 모든 하위 디렉터리를 콘솔뷰에 출력
    private void GetSubDirInfo(string path, StreamWriter funcSw)
    {
        Debug.Log(path);
        funcSw.WriteLine(path);
        string[] subDirectorys = Directory.GetDirectories(path);
        foreach (string item in subDirectorys)
        {
            GetSubDirInfo(item,funcSw);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //문제1번 : 문자열의 데이터를 바이트 배열로 저장
            string str = "임시글자123";
            byte[] bArr = new byte[str.Length];
            bArr = Encoding.Unicode.GetBytes(str);

            //문제2번 : 배열의 데이터를 문자열로 저장
            string afterStr = Encoding.Unicode.GetString(bArr);
            Debug.Log(afterStr);
        }
    }
}
