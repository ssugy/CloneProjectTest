using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 슬롯은 아이콘을 알고 있어야 한다.
/// </summary>
public class Std_Slot : MonoBehaviour
{
    public Image icon;  // 내 슬롯의 자식imgage를 icon  -> uiIcon
    private RectTransform rcTransform;  // 슬롯의 rectransform;
    private Rect rc; // 외부에서 set못하게 하려고 프로퍼티로 지정
    private Rect RC // 외부에서 set못하게 하려고 프로퍼티로 지정
    {
        get
        {
            rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;
            rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;
            Debug.Log($"22rc.x {rc.x} || {rc.xMin} || {rc.width}");
            return rc;
        }
    }    // 이걸 좌상단, 우하단으로 해서 구현 -> 과거 윈도우즈 프로그래밍, 과거 유니티 방식

    void Start()
    {
        rcTransform = GetComponent<RectTransform>();
        //Debug.Log($"rcTransform.position {rcTransform.position} || {rcTransform.rect.width * 0.5f}");
        //rc.x = rcTransform.position.x - rcTransform.rect.width * 0.5f;    // RC 쓰기 때문에 이거 필요없음
        //rc.y = rcTransform.position.y + rcTransform.rect.height * 0.5f;   // RC 쓰기 때문에 이거 필요없음
        ////Debug.Log($"11rc.x {rc.x}");
        //rc.xMin = rc.x;   // 이것도 필요한가 x좌표의 최소값이 뭔상관이지 더 문제되는거 아닌가?
        //rc.yMin = rc.y;    // 이걸 어떤걸로 설정하던 아래의 width height설정을 하게되면 자동으로 초기화가 이루어진다.
        //rc.xMax = rc.xMin + rc.width;
        //rc.xMax = rc.xMin + rc.height;
        rc.width = rcTransform.rect.width;
        rc.height = rcTransform.rect.height;
        //Debug.Log($"22rc.x {rc.x}");
    }

    /// <summary>
    /// 매개변수로 전달 된 _pos가 rc에 포함 되는지 아닌지 검사
    /// </summary>
    /// <param name="pos">개별 슬롯의 터치 위치(월드 포지션)</param>
    /// <returns></returns>
    public bool IsInRect(Vector2 _pos)
    {
        //Debug.Log(_pos.x >= RC.x);
        //Debug.Log($"{_pos.x} ||{RC.x}|| {RC.width}|| {_pos.x <= RC.x + RC.width}");
        //Debug.Log(_pos.y <= RC.y);
        //Debug.Log(_pos.y >= RC.y + RC.height);
        if (   _pos.x >= RC.x 
            && _pos.x <= RC.x + RC.width
            && _pos.y <= RC.y 
            && _pos.y >= RC.y - RC.height)
        {
            return true;
        }
        return false;
    }
}
