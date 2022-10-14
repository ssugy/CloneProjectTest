using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectCheck : MonoBehaviour
{
    private RectTransform rt;
    public Rect inspectRect;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void ShowRectData()
    {
        //Debug.Log($"rt transform position : {rt.transform.position}");
        //Debug.Log($"rt transform Lposition : {rt.transform.localPosition}");
        //Debug.Log($"rt position : {rt.position}");
        //Debug.Log($"rt width hegith : {rt.rect.width} {rt.rect.height}");
        Debug.Log($"rt x y : {rt.rect.x} {rt.rect.y}");
        Debug.Log($"rt xMin yMin : {rt.rect.xMin} {rt.rect.yMin}");
        Rect newRt = rt.rect;
        newRt.xMin = 10;
        newRt.yMin = 20;
        inspectRect = newRt;
        Debug.Log($"rt xMin yMin : {rt.rect.xMin} {rt.rect.yMin}");

        Debug.Log($"rt xMax yMax : {rt.rect.xMax} {rt.rect.yMax}");
        //Debug.Log($"rt position : {rt.position}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowRectData();
        }
    }
}
