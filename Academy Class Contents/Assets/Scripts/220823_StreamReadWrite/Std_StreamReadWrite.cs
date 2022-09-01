using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Std_StreamReadWrite : MonoBehaviour
{
    private void Start()
    {
        WriteData("test.txt");
        ReadData("test.txt");
    }

    private void WriteData(string _filename)
    {
        string path = Application.dataPath + "/" + _filename;
        
        /**
         * using 구문에서 생성한 참조형 인스턴스는 가비지 콜렉터에 의해서 관리되지 않고, 블록이 끝날 때 바로 삭제 된다.
         * 개발자가 항상 close를 사용하기에 불편해서 이런식으로 사용하면 편리하게 관리 할 수 있다.
         * 주로 한 번 사용하고 참조가 필요없는 인스턴스는 using구문에서 인스턴스를 생성합니다.
         * IDisposable의 역할을 대신하는 개념.
         */
        using (StreamWriter sr = new StreamWriter(path))
        {
            sr.WriteLine("하나둘셋넷");
            sr.WriteLine("하나둘셋");
            sr.WriteLine("하나둘");
            Debug.Log("작성완료");
            sr.Close();
        }
    }

    private void ReadData(string _filename)
    {
        string path = Application.dataPath + "/" + _filename;
        using (StreamReader sr = new StreamReader(path))
        {
            Debug.Log("****** 읽은 데이터 ******");
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
            }
            sr.Close();
        }
    }
}
