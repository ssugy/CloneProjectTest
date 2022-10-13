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
        // ��ư���ڱ��� �Ÿ��� �� ǥ���ϱ�
        legacyText = GetComponent<Text>();
        InvokeRepeating("BlinkText", 0, 2); // �̷��� ó�� �� �� ������, �׶��̼� ȿ���� ���ش�.
        
        //����� ��Ÿ��
        tmpElapsed = elapsed;
        textColor = legacyText.color;

        // ��������Ʈ �׽�Ʈ
        test += Sample;
        test += Sample;
        test += Sample;
        test();
    }

    public float elapsed;   //�ܺο��� �� ����
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

    #region �ؽ�Ʈ ��ũ ȿ��
    public void BlinkText()
    {
        Debug.Log("�κ�ũ ������ �ݺ��Ǵ��� Ȯ���ϴ� �뵵");
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

    #region UI �̺�Ʈ �ڵ鷯
    /// <summary>
    /// IPointerDownHandler�������̽��� ���ؼ� ��ũ��Ʈ�� ����
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnPointerDown(PointerEventData _eventData)
    {
        Debug.Log("PointerDown" + _eventData.position);
    }

    /// <summary>
    /// Ŭ�� ��, �ٸ������� �巡���ؼ� ȭ�� ������ �̵� �� �÷��� ������ �ȴ�.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp" + eventData.position);
    }

    /// <summary>
    /// Ŭ�� ��, ����ĳ��Ʈ Ÿ�� ���� �ȿ��� ��ư�� ���� ������ ������ �ȴ�.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("PointerClick" + eventData.position);
    }
    #endregion

    #region ��������Ʈ ����
    delegate void func();   //�Լ� ���¸� ���� �����ϰ� ��� �Լ� �̸��� ��������Ʈ�� �ڷ����̴�.
    func test;  //�ش� ��������Ʈ �ڷ����� ������ �����ؾߵȴ�.

    private void Sample()
    {
        Debug.Log("����");
    }
    #endregion
}
