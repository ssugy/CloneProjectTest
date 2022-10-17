using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exam_Slot : MonoBehaviour
{
    public Image uiIcon;
    [SerializeField] private RectTransform rcTransform;
    Rect rc;
    public TextMeshProUGUI itemCountTxt;
    public int itemCnt;    //아이템의 수량

    public Rect RC
    {
        get
        {
            rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
            rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
            return rc;
        }
    }

    private void Awake()
    {
        
    }

    void Start()
    {
        rcTransform = GetComponent<RectTransform>();

        // x, y를 좌상단으로 하는 Rect 구조체 
        rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
        rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
        rc.xMin = rc.x;
        rc.yMin = rc.y;
        rc.xMax = rc.x + rcTransform.rect.width;
        rc.yMax = rc.y + rcTransform.rect.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;

        // 수량 랜덤하게 초기화
        itemCnt = Random.Range(1, 10);
        itemCountTxt.text = itemCnt.ToString();
    }
    // 매개변수로 전달된 _pos가 rc에 포함되는지 검사
    public bool IsInRect(Vector2 _pos)
    {
        if (_pos.x >= RC.x && 
            _pos.x <= RC.x + RC.width &&
            _pos.y >= RC.y - RC.height && 
            _pos.y <= RC.y)
            return true;
        return false;
    }

    public void SetItemCnt(int cnt)
    {
        itemCnt = cnt;
        itemCountTxt.text = itemCnt.ToString();
    }
}
