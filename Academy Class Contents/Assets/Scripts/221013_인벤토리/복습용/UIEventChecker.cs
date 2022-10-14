using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventChecker : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�� �巡��");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ���� �巡�� ������, �巡�׸� ���⶧�� �ƴ϶�
        //�巡�׸� ���߰� + �հ����� �� ���̴�.
        //�ٸ� �巡�׸� ���� �ʴ� ��쿡�� ����巡�׵� �߻����� �ʴ´�.
        Debug.Log("���� �巡��");  
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("������ �ٿ� �ڵ鷯"); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ������ ����, ������ down�� ����Ǿ���� ������ �ȴ�.
        Debug.Log("������ �� �ڵ鷯");
    }
}
