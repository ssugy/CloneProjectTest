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
         * using �������� ������ ������ �ν��Ͻ��� ������ �ݷ��Ϳ� ���ؼ� �������� �ʰ�, ����� ���� �� �ٷ� ���� �ȴ�.
         * �����ڰ� �׻� close�� ����ϱ⿡ �����ؼ� �̷������� ����ϸ� ���ϰ� ���� �� �� �ִ�.
         * �ַ� �� �� ����ϰ� ������ �ʿ���� �ν��Ͻ��� using�������� �ν��Ͻ��� �����մϴ�.
         * IDisposable�� ������ ����ϴ� ����.
         */
        using (StreamWriter sr = new StreamWriter(path))
        {
            sr.WriteLine("�ϳ��Ѽ³�");
            sr.WriteLine("�ϳ��Ѽ�");
            sr.WriteLine("�ϳ���");
            Debug.Log("�ۼ��Ϸ�");
            sr.Close();
        }
    }

    private void ReadData(string _filename)
    {
        string path = Application.dataPath + "/" + _filename;
        using (StreamReader sr = new StreamReader(path))
        {
            Debug.Log("****** ���� ������ ******");
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
            }
            sr.Close();
        }
    }
}
