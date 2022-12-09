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

    // 프로퍼티를 이용해서 sBuffer에 데이터를 이어서 대입하는 프로그램 코드를 작성
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
        // 버퍼에 패킷을 저장하는 코드
        CURINDEX =  (int)ePACKETMARKER.INITIALIZE;
        READCOUNT = (int)ePACKETMARKER.INITIALIZE;
        ADDPACKET = BitConverter.GetBytes((int)1234);   //4바이트를 sBuffer에 저장
        ADDPACKET = BitConverter.GetBytes((short)26); //2바이트를 이어서 sBuffer에 저장
        byte[] strbyteArr = Encoding.Default.GetBytes("안녕하세요");
        // 1. 문자열의 바이트 길이 저장
        // 2. 문자열의 내용을 바이트로 변환해서 저장
        ADDPACKET = BitConverter.GetBytes((short)strbyteArr.Length); //2바이트를 이어서 sBuffer에 저장
        ADDPACKET = strbyteArr;
        // 
        // sBuffer에 있는 내용을 자료형에 맞도록 파싱
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
