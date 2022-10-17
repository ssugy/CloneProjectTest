using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Std_WorlToSceen : MonoBehaviour, IPointerDownHandler
{
    public ScrollRect myScrollRect;
    public RectTransform scrollableContent;

    public GameObject cube;
    public void Start()
    {
        myScrollRect.content = scrollableContent;

        Debug.Log(scrollableContent.childCount);    // ÄÜÅÙÃ÷ÀÇ 

        Debug.Log(Camera.main.WorldToScreenPoint(cube.transform.position));
        Debug.Log(Camera.main.ScreenToWorldPoint(cube.transform.position));

    }

    public void OnImgClick(BaseEventData _data)

    {

        PointerEventData Data = _data as PointerEventData;

        Debug.Log("OnImgClick Å¬¸¯ÇÑ À§Ä¡ = " + Data.position);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnImgClick(eventData);
    }
}
