using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum eHEADER{ NONE = 0, CHARMOVE = 1}
public struct MOVEPACKET
{
    public short header;
    public uint uid;
    public float xpos;
    public float ypos;
    public float zpos;
}
public class PacketExample : MonoBehaviour
{
    public Packet packet;
    byte[] sendBuffer;
    Queue<byte[]> packetList;

    void Start()
    {
        sendBuffer = new byte[128];
        packetList = new Queue<byte[]>();
    }
    public void EnQueue(byte[] _packet)
    {
        byte[] _tmp = new byte[128];
        Array.Copy(_packet, _tmp, _packet.Length);
        packetList.Enqueue(_tmp);
    }
    public byte [] DeQueue()
    {
        return packetList.Dequeue();
    }
    public void MovePacket(MOVEPACKET _movePacket)
    {
        packet.BUFFER = sendBuffer;
        packet.CURINDEX = (int)ePACKETMARKER.INITIALIZE;
        packet.READCOUNT = (int)ePACKETMARKER.INITIALIZE;
        packet.ADDPACKET = BitConverter.GetBytes(_movePacket.header);
        packet.ADDPACKET = BitConverter.GetBytes(_movePacket.uid);
        packet.ADDPACKET = BitConverter.GetBytes(_movePacket.xpos);
        packet.ADDPACKET = BitConverter.GetBytes(_movePacket.ypos);
        packet.ADDPACKET = BitConverter.GetBytes(_movePacket.zpos);
        //sendBuffer에 있는 내용을 send
    }
    public void SendCallBack()
    {
        EnQueue(sendBuffer);
    }
    // Update is called once per frame
    void Update()
    {
        // client에 존재하는 프로그램 코드
        if(Input.GetMouseButtonDown(0))
        {
            MOVEPACKET movePacket;
            movePacket.header = (short)eHEADER.CHARMOVE;
            movePacket.uid = (uint)2764;
            movePacket.xpos = (float)30.4f;
            movePacket.ypos = (float)1.4f;
            movePacket.zpos = (float)10.4f;
            MovePacket(movePacket);
        }
        // 패킷 파싱
        packet.BUFFER = DeQueue();
        packet.CURINDEX = (int)ePACKETMARKER.INITIALIZE;
        packet.READCOUNT = (int)ePACKETMARKER.INITIALIZE;
        short header = BitConverter.ToInt16(packet.GETSHORT);
        switch((int)header)
        {
            case (int)eHEADER.CHARMOVE:
            {
                uint uid = BitConverter.ToUInt32(packet.GETINT);
                float x = BitConverter.ToSingle(packet.GETFLOAT);
                float y = BitConverter.ToSingle(packet.GETFLOAT);
                float z = BitConverter.ToSingle(packet.GETFLOAT);
                //캐릭터 이동을 Update에서 적용
            }
            break;
        }
    }
}
