using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �������̵� // �����ε�
/// </summary>
public class NE_Class1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�� �巡��");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end �巡��");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("����Ʈ �ٿ�");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("����Ʈ up");
    }
}
