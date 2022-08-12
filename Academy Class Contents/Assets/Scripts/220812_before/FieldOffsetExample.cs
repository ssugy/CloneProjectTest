using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class FieldOffsetExample : MonoBehaviour
{
    [StructLayout(LayoutKind.Explicit)]
    struct CustomData
    {
        [FieldOffset(0)]
        public long data;
        [FieldOffset(0)]
        public byte hp;
        [FieldOffset(1)]
        public byte mana;
        [FieldOffset(2)]
        public byte con;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct XDATA
    {
        char a;
        char b;
        char c;
    }

    struct XDATA2
    {
        char a;
        int dd;
        short b;
        char c;
    }

    struct XDATA3
    {
        long cc;
        int dd;
        short b;
        char c;
    }

    void Start()
    {
        CustomData test = new CustomData();
        test.hp = 100;
        test.mana = 200;
        test.con = 254;
        Debug.Log(test.data);

        CustomData otherTest = new CustomData();
        otherTest.data = test.data;
        Debug.Log("hp = " + otherTest.hp);
        Debug.Log("mana = " + otherTest.mana);
        Debug.Log("con = " + otherTest.con);

        // 구조체의 크기
        XDATA xdata = new XDATA();
        int size = Marshal.SizeOf(xdata);
        Debug.Log("XDATA의 크기 = " + size);

        XDATA2 xdata2 = new XDATA2();
        size = Marshal.SizeOf(xdata2);
        Debug.Log("XDATA2의 크기 = " + size);

        XDATA3 xdata3 = new XDATA3();
        size = Marshal.SizeOf(xdata3);
        Debug.Log("XDATA3의 크기 = " + size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
