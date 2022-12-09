using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class ArrayCopy : MonoBehaviour
{
    public enum ePACKETMARKER { INITIALIZE = 0 };

    byte[] sBuffer;
    public int CURINDEX { get; set; }
    public int READCOUNT { get; set; }
    void Awake()
    {
        sBuffer = new byte[128];
    }

    // ������Ƽ�� �̿��ؼ� sBuffer�� �����͸� �̾ �����ϴ� ���α׷� �ڵ带 �ۼ�
    public byte [] ADDPACKET
    {
        get { return sBuffer; }
        set
        {
            byte[] _value = value;
            for (int i = 0; i < _value.Length; i++)
                sBuffer[CURINDEX++] = _value[i];
        }
    }
    public byte [] GETINT
    {
        get
        {
            byte[] results = new byte[4];
            int j = 0;
            for( int i = CURINDEX; i < CURINDEX + 4; i++)
            {
                results[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 4;
            return results;
        }
    }
    public byte [] GETLONG
    {
        get
        {
            byte[] results = new byte[8];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 8; i++)
            {
                results[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 8;
            return results;
        }
    }
    public byte [] GETSHORT
    {
        get
        {
            byte[] results = new byte[2];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 2; i++)
            {
                results[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 2;
            return results;
        }
    }
    public byte [] GETFLOAT
    {
        get
        {
            byte[] results = new byte[4];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 4; i++)
            {
                results[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 4;
            return results;
        }
    }
    public byte [] GETDOUBLE
    {
        get
        {
            byte[] results = new byte[8];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 8; i++)
            {
                results[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + 8;
            return results;
        }
    }
    public byte [] GETBYTES
    {
        get
        {
            byte[] results = new byte[READCOUNT];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + READCOUNT; i++)
            {
                results[j++] = sBuffer[i];
            }
            CURINDEX = CURINDEX + READCOUNT;
            return results;
        }
    }
    void Start()
    {
        // ���ۿ� ��Ŷ�� �����ϴ� �ڵ�
        CURINDEX =  (int)ePACKETMARKER.INITIALIZE;
        READCOUNT = (int)ePACKETMARKER.INITIALIZE;
        ADDPACKET = BitConverter.GetBytes((int)1234);   //4����Ʈ�� sBuffer�� ����
        ADDPACKET = BitConverter.GetBytes((short)26); //2����Ʈ�� �̾ sBuffer�� ����
        byte[] strbyteArr = Encoding.Default.GetBytes("�ȳ��ϼ���");
        // 1. ���ڿ��� ����Ʈ ���� ����
        // 2. ���ڿ��� ������ ����Ʈ�� ��ȯ�ؼ� ����
        ADDPACKET = BitConverter.GetBytes((short)strbyteArr.Length); //2����Ʈ�� �̾ sBuffer�� ����
        ADDPACKET = strbyteArr;
        // 
        // sBuffer�� �ִ� ������ �ڷ����� �µ��� �Ľ�
        CURINDEX = (int)ePACKETMARKER.INITIALIZE;
        READCOUNT = (int)ePACKETMARKER.INITIALIZE;
        int number = BitConverter.ToInt32(GETINT);
        short age = BitConverter.ToInt16(GETSHORT);
        READCOUNT = BitConverter.ToInt16(GETSHORT);
        string str = Encoding.Default.GetString(GETBYTES);
        Debug.Log("number = " + number);
        Debug.Log("age = " + age);
        Debug.Log("readCount = " + READCOUNT);
        Debug.Log("string = " + str);
    }

    void Update()
    {
        
    }
}
