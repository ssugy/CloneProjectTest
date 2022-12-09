using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum ePACKETMARKER { INITIALIZE = 0 };
public class Packet : MonoBehaviour
{
    public int CURINDEX { get; set; }
    public int READCOUNT { get; set; }

    public byte[] BUFFER {  get;  set; }
    public byte[] ADDPACKET
    {
        get { return BUFFER; }
        set
        {
            byte[] _value = value;
            for (int i = 0; i < _value.Length; i++)
                BUFFER[CURINDEX++] = _value[i];
        }
    }
    public byte[] GETINT
    {
        get
        {
            byte[] results = new byte[4];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 4; i++)
            {
                results[j++] = BUFFER[i];
            }
            CURINDEX = CURINDEX + 4;
            return results;
        }
    }
    public byte[] GETLONG
    {
        get
        {
            byte[] results = new byte[8];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 8; i++)
            {
                results[j++] = BUFFER[i];
            }
            CURINDEX = CURINDEX + 8;
            return results;
        }
    }
    public byte[] GETSHORT
    {
        get
        {
            byte[] results = new byte[2];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 2; i++)
            {
                results[j++] = BUFFER[i];
            }
            CURINDEX = CURINDEX + 2;
            return results;
        }
    }
    public byte[] GETFLOAT
    {
        get
        {
            byte[] results = new byte[4];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 4; i++)
            {
                results[j++] = BUFFER[i];
            }
            CURINDEX = CURINDEX + 4;
            return results;
        }
    }
    public byte[] GETDOUBLE
    {
        get
        {
            byte[] results = new byte[8];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + 8; i++)
            {
                results[j++] = BUFFER[i];
            }
            CURINDEX = CURINDEX + 8;
            return results;
        }
    }
    public byte[] GETBYTES
    {
        get
        {
            byte[] results = new byte[READCOUNT];
            int j = 0;
            for (int i = CURINDEX; i < CURINDEX + READCOUNT; i++)
            {
                results[j++] = BUFFER[i];
            }
            CURINDEX = CURINDEX + READCOUNT;
            return results;
        }
    }

    void Awake()
    {

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
