using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEditor;
using TMPro;

public class Std_Inventory : MonoBehaviour
                            , IPointerDownHandler
                            ,IDragHandler
                            , IPointerUpHandler
                            //, IDropHandler    //�̰Ŵ� ���ڸ����� �� �� ������ �߻��Ѵ�. �̰� pointerUP�� ��ġ�� �ʴ´�.
{
    public List<Std_Slot> slots;
    // ������ Ŭ���ϸ� selectedItem�� �����̰� �ϴ� ��.
    public Image selectedItem;      // �� �̹�����, �̵��� �� �����ֱ� ���� �̹���.
    public int selectedSlotIndex;   // ���� ó�� Ŭ�� �� ���� �����ε����� �̾߱��Ѵ�.(���࿡ 1���ε������� 2���������� ���°��, �� ������ 1�� �����ϰ� �Ѵ�.)

    private void Start()
    {
        selectedSlotIndex = -1; //�ƹ��͵� ���� ���ϸ� -1 �ֱ�
        selectedItem.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log($"{eventData.position}����Ʈ �ٿ� ����");
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(eventData.position))
            {
                // ���ҽ��� �ε��ϴ� ���, ���� ���ҽ� �ε���ϰ� �׳� �ٷ� �������� �ϱ�
                //����� �ڵ� ����α� - �����Ͻô� �����
                //selectedItem.sprite = Resources.Load<Sprite>($"Icon/{slots[i].icon.sprite.name}");
                // �����������°� ��������� ������, �����ϰ� �ִٴ� �̾߱��ε�.. ��Ȯ�ϰ� ���ظ���. �� �ϸ� �ȵǴ���.
                //�߰��� �ٲ����� ���µ� ���ҽ� �ε带 ������ Ŭ�� �� ������ �ϸ� �װ� ������ �������� �𸣰���.
                selectedItem.gameObject.SetActive(true);
                selectedItem.sprite = slots[i].icon.sprite;   // ���� �ȴ޾Ƶ���
                slots[i].icon.gameObject.SetActive(false);
                selectedItem.transform.position = eventData.position;

                Debug.Log($"������ ���� : {slots[i].name} ���� Ŭ����.");
                selectedSlotIndex = i;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (selectedSlotIndex != -1)    
        {
            selectedItem.transform.position = eventData.position;
        }
    }

    // �̰��ϴ� ������ ���ڸ����� �����ٰ� �� ��, drop�� �� �� ������ �� �� �ִ�.
    // ����� �ڵ尡 �ʹ� ��ȿ������ �� ����. �ƹ�������.
    public void OnPointerUp(PointerEventData eventData)
    {
        if (selectedSlotIndex == -1)    //���� ���̱� ���� ��ġ
            return;

        int tmpSelectedIconIndex = -1;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(eventData.position))
            {
                tmpSelectedIconIndex = i;
                break;
            }
        }

        if (tmpSelectedIconIndex == -1 || tmpSelectedIconIndex == selectedSlotIndex)
        {
            // ���� ������°� �ƴ϶��, �̰͸� �߰��ϸ� �ȴ�.
            slots[selectedSlotIndex].icon.gameObject.SetActive(true);

            // ���� ������ ������ ��� ������ �δ� ����̴�. (����� �������� ������� �� ó�� ��������.)
            selectedSlotIndex = -1;
            selectedItem.gameObject.SetActive(false);
        }
        else
        {
            //���Ⱑ �������� ���, �ٸ������۰� �����ϴ� ��ġ�̴�.
            Sprite tmSp = slots[tmpSelectedIconIndex].icon.sprite;
            slots[tmpSelectedIconIndex].icon.sprite = selectedItem.sprite;
            slots[selectedSlotIndex].icon.sprite = tmSp;
            slots[selectedSlotIndex].icon.gameObject.SetActive(true);
            // ���α�
            selectedItem.gameObject.SetActive(false);
        }
    }

    // �³�. ������� ���ڸ����� �� �� ������ �߻��Ѵ�.
    //public void OnDrop(PointerEventData eventData)
    //{
    //    selectedSlotIndex = -1;
    //    slots[selectedSlotIndex].icon.sprite = selectedItem.sprite;
    //    selectedItem.gameObject.SetActive(false);
    //}


    // ������ ����� �����͸� ���󰡴°Ŷ� �巡�װ� �ƴϴ�.(���콺 ������ ���� �ʾƵ� �̵���.)
    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    selectedItem.gameObject.transform.position = eventData.position;
    //}
}
