using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class Std_StickController : MonoBehaviour
{
    private Vector3 dir;
    static public Vector3 figuredDir;

    private void Start()
    {
        dir = new Vector3();
    }

    public GameObject outterStick;
    public GameObject innerStick;
    [Range(0, 200)] public float maxRange = 100;

    public void StickPointDownControl(BaseEventData eventData)
    {
        // ����ȯ�� ����� �Ѵ�.
        PointerEventData pointerEventData = eventData as PointerEventData;
        stickStartPos = innerStick.transform.position;
        innerStick.transform.position = pointerEventData.position;
    }

    public void StickPointUpControl(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        innerStick.transform.localPosition = Vector3.zero;
        dir = Vector3.zero;
        figuredDir = Vector3.zero;
    }

    Vector2 stickStartPos;
    float stickDist;
    public void StickDragControl(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        // �ִ� �̵������� ����������Ѵ�. (�߽����κ��� ������ �� ���� �����ϰ� �̷������� ����
        stickDist = Vector3.Distance(stickStartPos, pointerEventData.position);
        dir = pointerEventData.position - stickStartPos;
        if (stickDist < maxRange)
        {
            figuredDir = ((pointerEventData.position - stickStartPos).magnitude / maxRange) * (pointerEventData.position - stickStartPos).normalized;
            innerStick.transform.position = pointerEventData.position;
        }
        else
        {
            figuredDir = (pointerEventData.position - stickStartPos).normalized;
            innerStick.transform.position = (pointerEventData.position - stickStartPos).normalized * maxRange + stickStartPos;   //�̰ű���.. ���� ��Ÿ �ȱ��ϰ� ������.
        }
        
    }
}
