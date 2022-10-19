using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

class Animal
{
    public int age;
    const int test = 10;

    //decimal a = 100000000000000000000000000000000000000000000000;


    virtual public void Speak()
    {
        Debug.Log("부모-스피크");
    }
}

class Dog : Animal
{
    override public void Speak()
    {

    }
}

public class NE_Basic : MonoBehaviour, IPointerDownHandler
{
    void Start()
    {
        //IF_Remind();
        //CodeBlock(1, 1.0f);
        Inherit();
    }


    #region 기본함수 생성
    // 함수 생성
    private void IF_Remind()
    {
        /**
         * 케이스 1번 : num = 12, num2 = 3
         * 케이스 2번 : num = 8, num2 = 7
         * 케이스 3번 : num = 8, num2 = 3
         * 케이스 4번 : num = 12, num2 = 7
         */

        int num = 10;
        int num2 = 5;

        if (num++ > 10 && --num2 < 5)   // 전위/후위 증감자
        {
            // 조건 : num이 10보다 크고 num2 5보다 작은경우 (and)
            Debug.Log($"위 {num} || {num2}");    //10 4
        }
        else
        {
            // 조건 : num이 10보다 작거나 같고, num2가 5보다 크면 (and? or?)
            Debug.Log($"아래 {num} || {num2}");   // 11 4????? 11에 5인데요?
        }
    }
    #endregion

    #region 인풋 필드 설명
    //-------------------------------- 인풋 필드 버튼설명
    public void ShowName(string str)
    {
        Debug.Log("권용훈 입니다." + str);
    }

    public void OnValueChanged(string str)
    {
        Debug.Log("OnValueChanged" + str);
    }

    public void OnEndEdit()
    {
        Debug.Log("OnEndEdit");
    }

    public void OnSelect()
    {
        Debug.Log("OnSelect");
    }

    public void DeSelect()
    {
        Debug.Log("디 DeSelect");
    }


    public void OnValueChanged2(float str)
    {
        Debug.Log("OnValueChanged" + str);
    }
    #endregion

    #region 코드블럭
    //-- 코드블럭
    int num1 = 1;
    /// <summary>
    /// 함수에 대한 설명추가
    /// </summary>
    /// <param name="a">a파라미터 설명</param>
    /// <param name="b">b파라미터 설명</param>
    public void CodeBlock(int a, float b)
    {
        NE_SampleClass ns = new NE_SampleClass(20);
        ns.ShowNE();    // 20
        NE_SampleClass ns2 = new NE_SampleClass();
        ns2.ShowNE();   //10

        ns.age = 15;
        ns2.ShowNE();   // 10
        ns.ShowNE();    // 15

        NE_SampleClass.age2 = 12;
        NE_SampleClass.ShowNE2();   // 12
    }

    private void OnEnable()
    {
        Debug.Log("온인에이블");
    }

    private void OnDisable()
    {
        int num = 0;
        {
            
        }
    }
    #endregion

    public void Inherit()
    {
        Animal ani2 = new Dog();

        Animal ani = new Animal();
        ani.Speak();

        Dog dog = new Dog();
        dog.age = 15;
    }


    public void OnPointerDown(PointerEventData eventData)   // 부모
    {
        OnImgClick(eventData);
    }

    public void OnImgClick(BaseEventData _data) //자식
    {
        //PointerEventData Data = _data as PointerEventData;
        PointerEventData Data;
        if (_data is PointerEventData)  // is : 바꿀수있냐? t / f
        {
            Data = _data as PointerEventData;
        }
        else
        {
            Data = null;
        }

        Debug.Log("OnImgClick 클릭한 위치 = " + Data.position);
    }


    public void OnImgClick2(int _data) //자식
    {
        //(빈칸)Data = _data as (빈칸);
        //Debug.Log("OnImgClick 클릭한 위치 = " + Data.position);

        List<string> list = new List<string>();
        foreach (var item in list)
        {
            Debug.Log(item);
        }

        var test = 10.0d;
        //bool test2 = 1;
    }

}
