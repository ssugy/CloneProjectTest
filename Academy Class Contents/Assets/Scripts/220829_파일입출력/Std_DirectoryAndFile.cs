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
        //Debug.Log($"���� ���丮 : {curDirectory}"); // ���� ���� ������Ʈ ���� ��ΰ� ����.
        //string[] subDirectory = Directory.GetDirectories(curDirectory);
        //foreach (string item in subDirectory)
        //{
        //    Debug.Log($"���� ���丮 : {item}");
        //}
        
        //string txtPath = $"{Application.dataPath}/sample.txt";
        //Debug.Log(txtPath);
        //using (StreamWriter sw = new StreamWriter(txtPath))
        //{
        //    string startPath = "D:/Work/Python";
        //    GetSubDirInfo(startPath, sw);
        //}

    }

    // D����̺� ��� ���� ���͸��� �ֺܼ信 ���
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
            //����1�� : ���ڿ��� �����͸� ����Ʈ �迭�� ����
            string str = "�ӽñ���123";
            byte[] bArr = new byte[str.Length];
            bArr = Encoding.Unicode.GetBytes(str);

            //����2�� : �迭�� �����͸� ���ڿ��� ����
            string afterStr = Encoding.Unicode.GetString(bArr);
            Debug.Log(afterStr);
        }
    }
}
