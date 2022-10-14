using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventChecker : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("온 드래그");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 엔드 드래그 조건이, 드래그를 멈출때가 아니라
        //드래그를 멈추고 + 손가락을 뗄 때이다.
        //다만 드래그를 하지 않는 경우에는 엔드드래그도 발생하지 않는다.
        Debug.Log("엔드 드래그");  
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("포인터 다운 핸들러"); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 포인터 업은, 포인터 down이 실행되어야지 실행이 된다.
        Debug.Log("포인터 업 핸들러");
    }
}
