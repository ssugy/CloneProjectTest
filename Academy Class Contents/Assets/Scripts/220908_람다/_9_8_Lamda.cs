using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 반환형식이 정수이고 매개변수가 정수인 델리게이트 선언
public delegate int DoN();
public delegate void DoV();

public class _9_8_Lamda : MonoBehaviour
{
    public delegate int Do(int _a); // Do라는 이름은 다른데서 사용중이라서 임시로 클래스 안으로 가져옴.
    Do doSomething;
    DoN doSomethingN;
    DoV doSomethingV;
    // 문제해결
    DoV ToDo;
    void Start()
    {
        // 람다식을 이용하여 함수를 정의하고 대입
        doSomething = (x) => x * x;
        doSomethingN = () => 2 * 2;
        doSomethingV = () => Debug.Log("123");
        // doSomething은 람다식으로 정의한 함수의 구문을 실행
        int result = doSomething(4);
        Debug.Log("결과 = " + result);
        doSomething = (x) => 
        {
            int result = x * x + 100;
            return result;
        };
        result = doSomething(2);
        Debug.Log("결과 = " + result);
        Test(doSomething, 2);

        List<int> list = new List<int>();
        for(int i = 0; i < 10; i++)
            list.Add(i);

        //int? tmp = list.Find(o => o == 99);
        int? findData = FindData(list, 99);
        if (findData.HasValue)
        {
            Debug.Log(findData);
        }
        else
        {
            Debug.Log("검색하는 데이터가 존재하지 않습니다.");
        }
        ToDo = null;
    }
    public int? FindData(List<int> _list, int _findData)
    {
        foreach(int one in _list)
        {
            if (one.Equals(_findData))
                return one;      
        }
        return null;
    }
    public void Test(Do _doSomething, int _arg)
    {
        int result = _doSomething(_arg);
        Debug.Log("Test = " + result);
    }

    // 특정 이벤트가 발생했을때 호출할 함수

    /*
     * 문제해결
    1. Update함수에서 조건문을 한번만 사용하여 특정 이벤트에만 함수 호출을 할수 있는 
        프로그램 코드를 작성하시오. 단, 함수 호출은 1번만 한다.
     */
    // 2번 이벤트 발생시 호출함수
    public void EventAction()
    {
        Debug.Log("EventAction");
    }
    public void StressTest(int _eventIndex, DoV _toDo)
    {
        Debug.Log(_eventIndex + " 번이벤트발생");
        for (int i = 0; i < 20000; i++)
        {
            ToDo += _toDo;
        }
    }
    public void SetEvent(int _eventIndex, DoV _toDo)
    {
        Debug.Log(_eventIndex + " 번이벤트발생");
        ToDo = _toDo;
        ToDo += _toDo;
    }
    public void SetEvent(int _eventIndex, DoV [] _toDos)
    {
        Debug.Log(_eventIndex + " 번이벤트발생");
        foreach(DoV one in _toDos)
        {
            ToDo += one;
        }
    }
    void Update()
    {
        // 문제해결 : 테스트
        // 마우스 이벤트가 발생했을때 2번 이벤트를 대입
        if(Input.GetMouseButtonDown(0))
        {
            //SetEvent(2, EventAction);
            StressTest(2, EventAction);
        }
        if(ToDo != null)
        {
            // 반환형식이 존재하는 함수일경우 각각의 함수를 배열로 저장한후 호출한다.
            //Delegate [] arrFunc = ToDo.GetInvocationList();
            //foreach(Delegate one in arrFunc)
            //{
            //    DoV f = (DoV)one;
            //    f();
            //}
            //ToDo -= ToDo;

            // 반환형식이 존재하지 않는 함수일 경우
            ToDo();
            Debug.Log("EndToDo");
            ToDo -= ToDo;
        }
    }
}
