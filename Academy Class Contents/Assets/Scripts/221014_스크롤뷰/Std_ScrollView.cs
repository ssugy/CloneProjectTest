using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ũ�Ѻ並 �ٷ�����ؼ��� ScrollRect�� �˰� �־�� �Ѵ�.
/// </summary>
public class Std_ScrollView : MonoBehaviour
{
    public ScrollRect scrollRect;
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.normalizedPosition = Vector3.zero; // ��ֶ�������� 0,0�� ��ġ�� ��, �ϴ��̴�.
        scrollRect.normalizedPosition = Vector3.one; // ��ֶ�������� 0,0�� ��ġ�� ��, �ϴ��̴�.
    }

    void Update()
    {
        //Vector2 tmp = scrollRect.normalizedPosition;    // ��ֶ����� ������ : ��ũ���� ��ġ
        //tmp.x += Time.deltaTime * 0.1f;
        //scrollRect.normalizedPosition = tmp;
        
    }
}
