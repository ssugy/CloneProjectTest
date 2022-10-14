using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class _10_13_Inventory : MonoBehaviour,IPointerDownHandler,IDragHandler,IEndDragHandler,IPointerUpHandler
{
    public List<_10_13_Slot> slotList;
    public Image selectedIcon;  
    private int selectedSlot;   // ������ ������ ����Ʈ �ε���
    private void Awake()
    {
        selectedSlot = -1;
        selectedIcon.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        //Debug.Log(_eventData.position);
        //foreach(_10_13_Slot one in slotList)
        for(int i =0; i < slotList.Count; i++)
        {
            if(slotList[i].IsInRect(_eventData.position) )
            {
                //���ҽ��̸�
                selectedSlot = i;
                selectedIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[i].uiIcon.sprite.name);
                selectedIcon.rectTransform.position = _eventData.position;
                selectedIcon.gameObject.SetActive(true);

                //slotList[i].uiIcon.gameObject.SetActive(false);
                //������ ����
                Debug.Log("������ ���� = " + slotList[i].gameObject.name);
            }    
        }
    }
    public void OnPointerUp(PointerEventData _eventData)
    {
        //����ִ� ������ ��� �Ʒ��� �ڵ带 �������� �ʾƵ� �ȴ�.
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

    public void OnEndDrag(PointerEventData _eventData)
    {
        if (selectedSlot == -1)
            return;

        // �������� ���� �������� ��
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].IsInRect(_eventData.position))
            {
                // ����� ���� ���
                if (slotList[i].uiIcon.sprite == null)
                {
                    slotList[i].uiIcon.gameObject.SetActive(true);
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[selectedSlot].uiIcon.sprite.name);

                    slotList[selectedSlot].uiIcon.sprite = null;
                    slotList[selectedSlot].uiIcon.gameObject.SetActive(false);
                }
                else
                {
                    // ä���� ���� ��� �� �������� ��ȯ
                    string tmpName = slotList[i].uiIcon.sprite.name;
                    slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/"+ slotList[selectedSlot].uiIcon.sprite.name);
                    slotList[selectedSlot].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + tmpName);
                }

                selectedIcon.sprite = null;
                selectedIcon.gameObject.SetActive(false);
                selectedSlot = -1;
                return;
            }
        }
    }
}
