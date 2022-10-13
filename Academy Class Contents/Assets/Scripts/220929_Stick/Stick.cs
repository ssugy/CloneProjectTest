using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stick : MonoBehaviour
{
    public static Stick instance;
    public Image inner;
    public RectTransform rcTr;
    Vector3 startPos;
    public Vector3 dir { get; set; }
    float radius;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        startPos = inner.transform.position;
        radius = rcTr.sizeDelta.x * 0.5f;
        dir = Vector3.zero;
    }
    public void OnPointerDown(BaseEventData _eventData)
    {
        // Down위치를 알고자 한다면
        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log("다운위치 = " + eventData.position);
        inner.transform.position = eventData.position;
    }
    public void OnPointerUp(BaseEventData _eventData)
    {
        // Down위치를 알고자 한다면
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = startPos;
    }
    public void OnBeginDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = eventData.position;
    }
    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        dir = eventData.position - (Vector2)startPos;
        float distance = Vector3.Distance(startPos, eventData.position);
        if (distance > radius)
            inner.transform.position = startPos + dir.normalized * radius;
        else
        {
            inner.transform.position = startPos + dir.normalized * distance;
        }
    }
    public void OnEndDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        inner.transform.position = startPos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
