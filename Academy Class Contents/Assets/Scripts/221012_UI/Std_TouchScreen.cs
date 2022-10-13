using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Std_TouchScreen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private Text legacyText;
    void Start()
    {
        // 버튼깜박깜빡 거리는 것 표현하기
        legacyText = GetComponent<Text>();
        InvokeRepeating("BlinkText", 0, 2); // 이렇게 처리 할 수 있지만, 그라데이션 효과는 못준다.
        
        //강사님 스타일
        tmpElapsed = elapsed;
        textColor = legacyText.color;

        // 델리게이트 테스트
        test += Sample;
        test += Sample;
        test += Sample;
        test();
    }

    public float elapsed;   //외부에서 값 지정
    private float tmpElapsed;
    Color textColor;
    private void Update()
    {
        //tmpElapsed = tmpElapsed - Time.deltaTime;
        //if (tmpElapsed <= 0)
        //{
        //    tmpElapsed = elapsed;
        //    if (legacyText.color.a == 0)
        //    {
        //        textColor.a = 1;
        //        legacyText.color = textColor;
        //    }
        //    else
        //    {
        //        textColor.a = 0;
        //        legacyText.color = textColor;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Invoke("TestInvoke",2);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    private void TestInvoke()
    {
        Debug.Log("test");
    }

    #region 텍스트 블링크 효과
    public void BlinkText()
    {
        Debug.Log("인보크 리피팅 반복되는지 확인하는 용도");
        Color textColor = legacyText.color;
        if (textColor.a == 0)
        {
            textColor.a = 1;
            legacyText.color = textColor;
        }
        else
        {
            textColor.a = 0;
            legacyText.color = textColor;
        }
    }
    #endregion

    #region UI 이벤트 핸들러
    /// <summary>
    /// IPointerDownHandler인터페이스를 위해서 스크립트로 제작
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnPointerDown(PointerEventData _eventData)
    {
        Debug.Log("PointerDown" + _eventData.position);
    }

    /// <summary>
    /// 클릭 후, 다른곳으로 드래그해서 화면 밖으로 이동 후 올려도 실행이 된다.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp" + eventData.position);
    }

    /// <summary>
    /// 클릭 후, 레이캐스트 타겟 범위 안에서 버튼을 뗏을 때에만 실행이 된다.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("PointerClick" + eventData.position);
    }
    #endregion

    #region 델리게이트 복습
    delegate void func();   //함수 형태를 먼저 선언하고 가운데 함수 이름이 델리게이트의 자료형이다.
    func test;  //해당 델리게이트 자료형의 변수를 선언해야된다.

    private void Sample()
    {
        Debug.Log("샘플");
    }
    #endregion
}
