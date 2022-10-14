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
        slotRect = rt.rect; // ���� �� ��Ʈ�� 0, 0, 0, 0���� �ʱ�ȭ �Ǿ��ִ� �����̴�.
        
        Debug.Log(slotRect.x);
        Debug.Log(slotRect.y);
        Debug.Log(slotRect.width);
        Debug.Log(slotRect.height);
    }

    public bool IsInRect(Vector2 pos)
    {
        Debug.Log("���� �ȿ� ���ԵǾ���? : " + slotRect.Contains(pos));
        return slotRect.Contains(pos);
    }
}
