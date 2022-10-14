using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스크롤뷰를 다루기위해서는 ScrollRect를 알고 있어야 한다.
/// </summary>
public class Std_ScrollView : MonoBehaviour
{
    public ScrollRect scrollRect;
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.normalizedPosition = Vector3.zero; // 노멀라이즈드의 0,0의 위치는 좌, 하단이다.
        scrollRect.normalizedPosition = Vector3.one; // 노멀라이즈드의 0,0의 위치는 좌, 하단이다.
    }

    void Update()
    {
        //Vector2 tmp = scrollRect.normalizedPosition;    // 노멀라이즈 포지션 : 스크롤의 위치
        //tmp.x += Time.deltaTime * 0.1f;
        //scrollRect.normalizedPosition = tmp;
        
    }
}
