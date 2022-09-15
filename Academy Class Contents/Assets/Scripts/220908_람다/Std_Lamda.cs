using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Std_Lamda : MonoBehaviour
{
    public delegate int Do(int _a);
    Do doSomeThing;

    public delegate void Func();
    Func showSomething;

    public delegate void Func2(int _a);
    Func2 doSomeThingParameter;
    private void Start()
    {
        #region 델리게이트 기본 사용방법
        //파라미터가 없는 경우 사용법
        showSomething = () => Debug.Log("");
        showSomething = () => { Debug.Log(""); };
        //showSomething = () => { Debug.Log("") };    // 에러
        showSomething = () => { Debug.Log("test"); System.Console.WriteLine("123"); };

        // 파라미터, 리턴타입이 있는 경우 사용법
        doSomeThing = (x) => x * x;
        doSomeThing = (x) => { return x * x; };
        //doSomeThing = (x) => { x * x; }   // 에러
        //doSomeThing = (x) => { x * x; };  // 에러
        doSomeThing = (x) => { System.Console.WriteLine(""); return x * x; };

        // 파라미터만 있는 경우 사용법
        doSomeThingParameter = (x) => Debug.Log(x);
        //doSomeThingParameter = (x) => x * x;    // 에러
        doSomeThingParameter = (x) => { Debug.Log(x); };

        int result = doSomeThing(2);
        Debug.Log(result);

        showSomething();
        #endregion

        #region 델리게이트 함수 파라미터로 사용
        // 이렇게 파라미터를 람다, 델리게이트로 사용하는 경우도 많다. (아래와 위의 결과는 같다.)
        Test((x) => {
            return x * x + 100;
        });

        Test(doSomeThing = (x) =>
        {
            return x * x + 100;
        });

        Test(doSomeThing = (x) =>
        {
            return x * x + 100;
        });

        Test(doSomeThing, 2);   //이렇게 사용해서 델리게이트의 파라미터를 추가 할 수 있다.
        #endregion

        #region 리스트 연동
        List<int> list = new List<int>();
        for (int i = 0; i < 10; i++)
            list.Add(i);

        var tmp = list.Find((o) => o == 99);
        Debug.Log(tmp); // 원하는 데이터 못찾으면 null이 아니라 0을 리턴한다.
                        // 그래서 원하는 데이터가 0인경우, 이게 못찾아서 0인지, 0을 찾아서 0인지를 알 수 없다.
        int? tmp2 = list.Find((a) => a == 99);  // null체크해도 결과는 0 동일하다.
        if (tmp2.HasValue)
            Debug.Log(tmp2);    //여기 구문이 출력되고 0이 나옴
        else
            Debug.Log("검색하는 데이터가 존재하지 않습니다.");  //여기는 출력되지 않는다.

        //int tmp3 = list.Find((a) => { return a.Equals(99) ? a : 10) };  // 이런식으로 안됨. 에러
        #endregion

        Todo = null;
    }

    //델리게이트를 파라미터로 받는경우
    public void Test(Do _doSomething)
    {
        int result = _doSomething(2);
        Debug.Log($"Test = {result}");
    }
    
    //델리게이트, 델리게이트의 파라미터를 받는경우
    public void Test(Do _doSomething, int _a)
    {
        int result = _doSomething(_a);
        Debug.Log($"Test = {result}");
    }
    
    // 이런식으로 list검색은 따로 함수를 만들어서 사용 할 수 있다.(이렇게하면 찾는것이 없으면 null반환 한다.)
    public int? FindData(List<int> _list, int _findData)
    {
        foreach (int item in _list)
        {
            if (item.Equals(_findData))
            {
                return _findData;
            }
        }
        return null;
    }

    #region 문제해결1
    //update함수에서 조건문을 한번만 사용하고 특정 이벤트에만 함수 호출을 할 수 있는 프로그램 코드를 작성하시오.
    //단 함수 호출은 1번만 한다.
    Func Todo;
    
    public void SetEvent(int eventIndex, Func _toDo)
    {
        Debug.Log($"{eventIndex} 이벤트 발생");
        Todo = _toDo;
        Todo += _toDo;  // 두번호출하게 하고 싶을 때
    }

    public void SetEvent(int eventIndex, Func[] _toDo)
    {
        Debug.Log($"{eventIndex} 이벤트 발생");
        foreach (Func item in _toDo)
        {
            Todo += item;   // 이런식으로 배열로 받으면, 배열에 저장된 호출순서를 원하는대로 정할 수 있다.
        }
    }

    int cnt = 0;
    public void EventAction()
    {
        Debug.Log($"{++cnt} EventAction");
    }
    
    // 3만개를 달아서 실행하기.
    private void StressTest(int eventIndex, Func _toDo)
    {
        Debug.Log($"{eventIndex} 이벤트 발생");
        for (int i = 0; i < 30000; i++)
            Todo += _toDo;
    }

    private void Update()
    {
        //마우스 왼쪽 버튼 눌럿을 때 실행하기
        if (Input.GetMouseButtonDown(0))
        {
            SetEvent(2, EventAction);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SetReturnEvent();   // 리턴값 있는 함수들의 체크를 위한 코드
        }

        if (Todo != null)
        {
            Todo();
            Todo = null;
        }

        if (returnSomething != null)
        {
            //int a = returnSomething(5);
            //Debug.Log($"{a} 최종리턴값");    // 이건 마지막 함수의 리턴값만 저장이 된다. 그래서 중간에 리턴되는 값을 가져오려면 구분해서 사용해야된다.

            Delegate[] arrFunc = returnSomething.GetInvocationList();
            foreach (Do item in arrFunc)
            {
                Debug.Log("구분해서 실행");
                item(5);
            }
            returnSomething = null;
        }
    }
    #endregion
    Do returnSomething = null;
    private void SetReturnEvent()
    {
        returnSomething += Sum;
        returnSomething += Multiple;
    }

    private int Sum(int a) 
    {
        Debug.Log(a + a);
        return a + a;
    }
    private int Multiple(int a)
    {
        Debug.Log(a * a);
        return a * a;
    }
}
