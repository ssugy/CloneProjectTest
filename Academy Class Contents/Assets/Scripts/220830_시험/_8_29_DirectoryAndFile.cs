using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class _8_29_DirectoryAndFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string curDirectory = Directory.GetCurrentDirectory();
        Debug.Log("���� ���丮 = " + curDirectory);
        string[] subDirectory = Directory.GetDirectories("D:\\");
        foreach (string one in subDirectory)
        {
            Debug.Log("���� ���丮 = " + one);
        }
        // ���ȣ��(Recursive) ( �ڽ��� �Լ� �ȿ��� �ڽ��� ȣ�� )
        // ����1) D����̺��� ��� ���� ���丮�� �ֺܼ信 ���
        // ����2) D����̺��� ��� ���� ���丮 �̸��� ���Ͽ� ����
        // ����3) ������Ʈ ������ Assets �������� ���� �̸��� ��� �ֺܼ信 ���
        //
        // ����1�� �Լ�
        // GetSubDirInfo("D:\\");
        //
        // ����2�� �Լ�
        WriteSubDirectoryInfo(Application.dataPath + "/" + "DDriveFolderName.txt");
        // ���ȣ�⿹)
        //CountDisplay(0);
        //
        // ���� 3�� ���α׷� �ڵ�
        string [] files = Directory.GetFiles(Application.dataPath);
        foreach (string one in files)
        {
            Debug.Log(one);
        }
        // PathŬ���� ��� ����
        string name = Path.GetDirectoryName(Application.dataPath);
        Debug.Log(name);
        // ���� ������ Combine
        string[] dirnames = { "Lee", "Test", "Cur", "Cur2" };
        string combinePath = Path.Combine(dirnames);
        Debug.Log(combinePath);
        // ���� '/' �� '\'�� ���� �ִ� ��� �ϳ��� ���ڷ� �����ϰ� �����Ѵ�.
        // \ ��¹���� \�տ� \�� �ٿ��ش�.
        string tmp = "������/�󸶹�\\�����";
        string replacedPath = tmp.Replace('\\', '/');
        Debug.Log(replacedPath);
    }
    public void GetSubDirInfo(string _dir)
    {
        string[] subDirectory = Directory.GetDirectories(_dir);
        foreach (string one in subDirectory)
        {
            Debug.Log(one);
            GetSubDirInfo(one);
        }
    }
    public void WriteSubDirectoryInfo(string _path)
    {
        //        string path = Application.dataPath + "/" + "DDriveFolderName.txt";
        using (StreamWriter sr = new StreamWriter(_path))
        {
            WriteSuDirInfo("D:\\Lee\\", _path, sr);
            sr.Close();
        }
    }
    public void WriteSuDirInfo(string _dir, string _path, StreamWriter _sr)
    {
        string[] subDirectory = Directory.GetDirectories(_dir);
        foreach (string one in subDirectory)
        {
            _sr.WriteLine(one);
            WriteSuDirInfo(one, _path, _sr);
        }
    }
    // ���ȣ�� �Լ� ��
    // �ڽ��� �Լ� �ȿ��� �ڽ��� �Լ��� ȣ��
    // �Լ� ȣ���� ����Ǳ� ���� �Լ��� �ٽ� ȣ���ϱ� ������ ȣ���� ����Ǳ� ������ ȣ�⽺�ÿ� �����Ѵ�.
    public void CountDisplay(int _count)
    {
        Debug.Log("_count = " + _count);
        if (_count == 10)
        {
            return;
        }
        CountDisplay(++_count);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
