using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerDownHandler
{
    public List<SlotData> slots = new List<SlotData>();

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(eventData.position))
            {
                Debug.Log(slots[i].name);
            }
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
