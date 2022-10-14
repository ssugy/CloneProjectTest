using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotData : MonoBehaviour
{
    public Image icon;
    private RectTransform rt;
    private Rect slotRect;
    public Rect RC
    {
        get
        {
            return slotRect;
        }
    }

    private void Start()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        rt = GetComponent<Image>().rectTransform;
        slotRect = rt.rect; // 현재 이 렉트는 0, 0, 0, 0으로 초기화 되어있는 상태이다.
        
        Debug.Log(slotRect.x);
        Debug.Log(slotRect.y);
        Debug.Log(slotRect.width);
        Debug.Log(slotRect.height);
    }

    public bool IsInRect(Vector2 pos)
    {
        Debug.Log("범위 안에 포함되었냐? : " + slotRect.Contains(pos));
        return slotRect.Contains(pos);
    }
}
