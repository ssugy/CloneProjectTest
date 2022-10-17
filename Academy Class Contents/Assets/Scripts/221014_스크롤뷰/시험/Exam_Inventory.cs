using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class Exam_Inventory : MonoBehaviour,IPointerDownHandler,IDragHandler,IEndDragHandler,IPointerUpHandler
{
    public List<Exam_Slot> slotList;
    public Image selectedIcon;
    public TextMeshProUGUI selectedIconItemCnt;
    private int selectedSlot;   // 선택한 슬롯의 리스트 인덱스
    private int itemCnt;
    private void Awake()
    {
        selectedSlot = -1;
        selectedIcon.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        for(int i =0; i < slotList.Count; i++)
        {
            if(slotList[i].IsInRect(_eventData.position) && slotList[i].uiIcon.sprite != null)
            {
                //리소스이름
                selectedSlot = i;
                itemCnt = slotList[i].itemCnt;  // 아이템 수량 저장
                selectedIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[i].uiIcon.sprite.name);
                selectedIcon.rectTransform.position = _eventData.position;
                selectedIcon.gameObject.SetActive(true);
                selectedIconItemCnt.text = itemCnt.ToString();

                slotList[i].uiIcon.gameObject.SetActive(false);
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

        //현재 위치 그대로 두는 경우
        if(tmpSelectedSlot != -1 && tmpSelectedSlot == selectedSlot)
        {
            slotList[selectedSlot].uiIcon.gameObject.SetActive(true);

            selectedIcon.sprite = null;
            selectedIcon.gameObject.SetActive(false);
            selectedSlot = -1;
        }

        // 완전히 외부에 아이템을 두는 경우
        if (tmpSelectedSlot == -1)
        {
            slotList[selectedSlot].uiIcon.gameObject.SetActive(true);
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

    public void OnEndDrag(PointerEventData _eventData)
    {
        if (selectedSlot == -1)
            return;

        // 내려놓는 곳의 아이템을 비교
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].IsInRect(_eventData.position))
            {
                // 비어져 있을 경우
                if (slotList[i].uiIcon.sprite == null)
                {
                    slotList[i].uiIcon.gameObject.SetActive(true);
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlot].uiIcon.sprite.name);
                    slotList[i].SetItemCnt(itemCnt);

                    slotList[selectedSlot].uiIcon.sprite = null;
                    slotList[selectedSlot].uiIcon.gameObject.SetActive(false);
                }
                else
                {
                    // 서로 같은 아이템인 경우 두 아이템을 하나로 합침
                    if (slotList[i].uiIcon.sprite.name.Equals(slotList[selectedSlot].uiIcon.sprite.name))
                    {
                        slotList[selectedSlot].uiIcon.sprite = null;
                        slotList[selectedSlot].SetItemCnt(0);
                        slotList[selectedSlot].uiIcon.gameObject.SetActive(false);

                        slotList[i].SetItemCnt(slotList[i].itemCnt + itemCnt);  // 수량만 추가하면되고, 이미지 교체는 필요없음.
                    }
                    else
                    {
                        // 서로 다른 아이템인 경우 서로 교환
                        string tmpName = slotList[i].uiIcon.sprite.name;
                        slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/"+ slotList[selectedSlot].uiIcon.sprite.name);
                        slotList[selectedSlot].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + tmpName);
                        slotList[selectedSlot].uiIcon.gameObject.SetActive(true);

                        int tmpItemCnt = slotList[i].itemCnt;   // 아이템 수량도 서로 교환
                        slotList[i].SetItemCnt(itemCnt);
                        slotList[selectedSlot].SetItemCnt(tmpItemCnt);
                    }
                }

                selectedIcon.sprite = null;
                selectedIcon.gameObject.SetActive(false);
                selectedSlot = -1;
                return;
            }
        }
    }
}
