using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class _10_13_Inventory : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    public List<_10_13_Slot> slotList;
    public Image selectedIcon;  
    private int selectedSlot;   // 선택한 슬롯의 리스트 인덱스
    private void Awake()
    {
        selectedSlot = -1;
        selectedIcon.gameObject.SetActive(false);
    }
    void Start()
    {
    }
    public void OnPointerDown(PointerEventData _eventData)
    {
        //Debug.Log(_eventData.position);
        //foreach(_10_13_Slot one in slotList)
        for(int i =0; i < slotList.Count; i++)
        {
            if(slotList[i].IsInRect(_eventData.position) )
            {
                //리소스이름
                selectedSlot = i;
                selectedIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[i].uiIcon.sprite.name);
                selectedIcon.rectTransform.position = _eventData.position;
                selectedIcon.gameObject.SetActive(true);
                //선택한 슬롯
                Debug.Log("선택한 슬롯 = " + slotList[i].gameObject.name);
            }    
        }
    }
    public void OnPointerUp(PointerEventData _eventData)
    {
        //비어있는 슬롯일 경우 아래의 코드를 실행하지 않아도 된다.
        if (selectedSlot == -1)
            return;
        int tmpSelectedSlot = -1;
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].IsInRect(_eventData.position))
            {
                tmpSelectedSlot = i;
                break;
            }
        }
        if(tmpSelectedSlot != -1 && tmpSelectedSlot == selectedSlot)
        {
            selectedIcon.sprite = null;
            selectedIcon.gameObject.SetActive(false);
            selectedSlot = -1;
        }
    }
    public void OnDrag(PointerEventData _eventData)
    {
        if(selectedSlot != -1)
            selectedIcon.rectTransform.position = _eventData.position;
    }
    void Update()
    {
        
    }
}
