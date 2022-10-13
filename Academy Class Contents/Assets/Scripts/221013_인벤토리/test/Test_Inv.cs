using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test_Inv : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerUpHandler
{
    public Image img;
    public void OnDrag(PointerEventData eventData)
    {
        img.rectTransform.position = eventData.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ã¹¹øÂ°");
        Debug.Log(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
