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
    private int selectedSlot;   // ������ ������ ����Ʈ �ε���
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
                //���ҽ��̸�
                selectedSlot = i;
                itemCnt = slotList[i].itemCnt;  // ������ ���� ����
                selectedIcon.sprite = Resources.Load<Sprite>("Icon/" + slotList[i].uiIcon.sprite.name);
                selectedIcon.rectTransform.position = _eventData.position;
                selectedIcon.gameObject.SetActive(true);
                selectedIconItemCnt.text = itemCnt.ToString();

                slotList[i].uiIcon.gameObject.SetActive(false);
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

        //���� ��ġ �״�� �δ� ���
        if(tmpSelectedSlot != -1 && tmpSelectedSlot == selectedSlot)
        {
            slotList[selectedSlot].uiIcon.gameObject.SetActive(true);

            selectedIcon.sprite = null;
            selectedIcon.gameObject.SetActive(false);
            selectedSlot = -1;
        }

        // ������ �ܺο� �������� �δ� ���
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
                    slotList[i].SetItemCnt(itemCnt);

                    slotList[selectedSlot].uiIcon.sprite = null;
                    slotList[selectedSlot].uiIcon.gameObject.SetActive(false);
                }
                else
                {
                    // ���� ���� �������� ��� �� �������� �ϳ��� ��ħ
                    if (slotList[i].uiIcon.sprite.name.Equals(slotList[selectedSlot].uiIcon.sprite.name))
                    {
                        slotList[selectedSlot].uiIcon.sprite = null;
                        slotList[selectedSlot].SetItemCnt(0);
                        slotList[selectedSlot].uiIcon.gameObject.SetActive(false);

                        slotList[i].SetItemCnt(slotList[i].itemCnt + itemCnt);  // ������ �߰��ϸ�ǰ�, �̹��� ��ü�� �ʿ����.
                    }
                    else
                    {
                        // ���� �ٸ� �������� ��� ���� ��ȯ
                        string tmpName = slotList[i].uiIcon.sprite.name;
                        slotList[i].uiIcon.sprite = Resources.Load<Sprite>("Icon/"+ slotList[selectedSlot].uiIcon.sprite.name);
                        slotList[selectedSlot].uiIcon.sprite = Resources.Load<Sprite>("Icon/" + tmpName);
                        slotList[selectedSlot].uiIcon.gameObject.SetActive(true);

                        int tmpItemCnt = slotList[i].itemCnt;   // ������ ������ ���� ��ȯ
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
