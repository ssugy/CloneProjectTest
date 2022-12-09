using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

/**
 * sBuffer�� �����͸� �̾ �����ϴ� �ڵ� �ۼ�.
 */
public class ArrayCopy_YH : MonoBehaviour
{
    byte[] sBuffer;
    int CURRENTINDEX { get; set; }
    int READCOUNT { get; set; }
    private void Awake()
    {
        sBuffer = new byte[128];
        CURRENTINDEX= 0;
    }

    // ������Ƽ�� �̿��Ͽ� sBuffer�� �����͸� �̾ �����ϴ� ���α׷� �ڵ带 �ۼ�
    public byte[] ADDPACKET { get { return sBuffer; } 
        set {
            for (int i = 0; i < value.Length; i++)
            {
                sBuffer[CURRENTINDEX++] = value[i];
            }
        }}
    public byte[] GETINT { get {
            int getLength = 4;
            byte[] result = new byte[getLength];
            for (int i = 0; i < sBuffer.Length; i++)
            {
                if (i < getLength)
                {
                    result[i] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength] = sBuffer[i];    // ������ ����
                }
            }
            return result;
        } }
    public byte[] GETSHORT { get {
            int getLength = 2;
            byte[] result = new byte[getLength];
            for (int i = 0; i < sBuffer.Length; i++)
            {
                if (i < getLength)
                {
                    result[i] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength] = sBuffer[i];    // ������ ����
                }
            }
            return result;
        } }
    public byte[] GETBYTES { get {
            byte[] byteLength = new byte[2];
            byteLength[0] = sBuffer[0];
            byteLength[1] = sBuffer[1];

            int getLength = BitConverter.ToInt16(byteLength);
            byte[] result = new byte[getLength];
            for (int i = 2; i < sBuffer.Length; i++)
            {
                if (i < getLength + 2)
                {
                    result[i-2] = sBuffer[i];
                }
                else
                {
                    sBuffer[i - getLength - 2] = sBuffer[i];    // ������ ����
                }
            }
            return result;
        } }
    private void Start()
    {
        READCOUNT = 0;

        ADDPACKET = BitConverter.GetBytes((int)1325);
        ADDPACKET = BitConverter.GetBytes((short)125);
        
        // ���ڿ� ����
        string str = "�ȳ��ϼ���";
        byte[] strByte = Encoding.Default.GetBytes(str);
        ADDPACKET = BitConverter.GetBytes((short)strByte.Length); // ���ڿ��� ���ڿ��� ���̸� ���� ����������Ѵ�.
        ADDPACKET = strByte;    // ���ڿ� ����

        // sbuffer�� �ִ� ������ �ڷ����� �°� ����
        Debug.Log(BitConverter.ToInt32(GETINT));
        Debug.Log(BitConverter.ToInt16(GETSHORT));
        Debug.Log(Encoding.UTF8.GetString(GETBYTES));
    }
}
