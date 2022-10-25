using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tm_Inventory : MonoBehaviour
{
    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set => slotCnt = value;
    }

    void Start()
    {
        slotCnt = 10;

        Debug.Log(SlotCnt);
        SlotCnt = 20;
        Debug.Log(slotCnt);
    }

    void Update()
    {
        
    }
}
