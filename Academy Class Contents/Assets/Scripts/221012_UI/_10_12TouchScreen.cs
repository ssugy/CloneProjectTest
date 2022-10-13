using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class _10_12TouchScreen : MonoBehaviour, IPointerDownHandler
{
    delegate void Do();
    public Text uiText;
    public float elapsed;
    private Color sourceColor;
    private Color destColor;
    private float tmpElapsed;
    Do blinkDo;

    void Start()
    {
        sourceColor = uiText.color;
        destColor = uiText.color;
        destColor.a = 0f;
        tmpElapsed = elapsed;
        blinkDo = OnColorWithTime;
    }
    void OnColor()
    {
        uiText.color = sourceColor;
        Invoke("OffColor", 0.4f);
    }
    void OffColor()
    {
        uiText.color = destColor;
        Invoke("OnColor", 0.4f);
    }
    void OnColorWithTime()
    {
        uiText.color = sourceColor;
        tmpElapsed -= Time.deltaTime;
        if (tmpElapsed <= 0)
        {
            blinkDo = OffColorWithTime;
            tmpElapsed = elapsed;
        }
    }
    void OffColorWithTime()
    {
        uiText.color = destColor;
        tmpElapsed -= Time.deltaTime;
        if (tmpElapsed <= 0)
        {
            blinkDo = OnColorWithTime;
            tmpElapsed = elapsed;
        }
    }
    public void OnPointerDown(PointerEventData _eventData)
    {
        Debug.Log("PointerDown À§Ä¡" + _eventData.position);
    }
    void Update()
    {
        blinkDo();
    }
}
