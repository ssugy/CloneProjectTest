using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 오버라이딩 // 오버로딩
/// </summary>
public class NE_Class1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("온 드래그");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end 드래그");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("포인트 다운");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("포인트 up");
    }
}
