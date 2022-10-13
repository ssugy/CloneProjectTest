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
                            //, IDropHandler    //이거는 제자리에서 뗄 때 문제가 발생한다. 이거 pointerUP과 겹치지 않는다.
{
    public List<Std_Slot> slots;
    // 아이템 클릭하면 selectedItem이 움직이게 하는 것.
    public Image selectedItem;      // 빈 이미지로, 이동할 때 보여주기 위한 이미지.
    public int selectedSlotIndex;   // 내가 처음 클릭 한 것의 슬롯인덱스를 이야기한다.(만약에 1번인덱스에서 2번에서손을 떼는경우, 이 변수는 1을 저장하게 한다.)

    private void Start()
    {
        selectedSlotIndex = -1; //아무것도 선택 안하면 -1 넣기
        selectedItem.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log($"{eventData.position}포인트 다운 실행");
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsInRect(eventData.position))
            {
                // 리소스로 로드하는 방식, 나는 리소스 로드안하고 그냥 바로 가져오게 하기
                //강사님 코드 적어두기 - 강조하시니 적어둠
                //selectedItem.sprite = Resources.Load<Sprite>($"Icon/{slots[i].icon.sprite.name}");
                // 직접가져오는거 하지말라는 이유가, 참조하고 있다는 이야기인데.. 정확하게 이해못함. 왜 하면 안되는지.
                //중간에 바뀔일이 없는데 리소스 로드를 아이템 클릭 할 때마다 하면 그게 성능이 좋은건지 모르겠음.
                selectedItem.gameObject.SetActive(true);
                selectedItem.sprite = slots[i].icon.sprite;   // 조건 안달아도됨
                slots[i].icon.gameObject.SetActive(false);
                selectedItem.transform.position = eventData.position;

                Debug.Log($"선택한 슬롯 : {slots[i].name} 슬롯 클릭함.");
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

    // 이걸하는 이유가 제자리에서 눌럿다가 뗄 때, drop은 그 때 문제가 될 수 있다.
    // 강사님 코드가 너무 비효율적인 것 같다. 아무리봐도.
    public void OnPointerUp(PointerEventData eventData)
    {
        if (selectedSlotIndex == -1)    //연산 줄이기 위한 조치
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
            // 만약 사라지는게 아니라면, 이것만 추가하면 된다.
            slots[selectedSlotIndex].icon.gameObject.SetActive(true);

            // 여기 조건이 아이템 끌어서 밖으로 두는 경우이다. (현재는 아이템이 사라지는 것 처럼 만들어놨다.)
            selectedSlotIndex = -1;
            selectedItem.gameObject.SetActive(false);
        }
        else
        {
            //여기가 아이템을 끌어서, 다른아이템과 스왑하는 위치이다.
            Sprite tmSp = slots[tmpSelectedIconIndex].icon.sprite;
            slots[tmpSelectedIconIndex].icon.sprite = selectedItem.sprite;
            slots[selectedSlotIndex].icon.sprite = tmSp;
            slots[selectedSlotIndex].icon.gameObject.SetActive(true);
            // 꺼두기
            selectedItem.gameObject.SetActive(false);
        }
    }

    // 맞네. 드랍류는 제자리에서 뗄 때 문제가 발생한다.
    //public void OnDrop(PointerEventData eventData)
    //{
    //    selectedSlotIndex = -1;
    //    slots[selectedSlotIndex].icon.sprite = selectedItem.sprite;
    //    selectedItem.gameObject.SetActive(false);
    //}


    // 포인터 무브는 포인터를 따라가는거라서 드래그가 아니다.(마우스 누르고 있지 않아도 이동됨.)
    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    selectedItem.gameObject.transform.position = eventData.position;
    //}
}
