using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NY_Test : MonoBehaviour, IPointerUpHandler
{

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("������ �� : " + eventData.position);
    }

    void Start()
    { 
        
    }
}
