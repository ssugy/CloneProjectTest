using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 람다식 -> 무명 메서드라고 칭함
 * => 연산자를 사용
 * => 왼쪽은 매개변수를 의미, 오른쪽은 식이나 문 코드블럭을 의미
 * 람다식에서는 매개변수를 정의할 때 데이터형을 명시하지 않아도 된다.
 * 
 * [식 람다에서는 연산결과를 리턴한다]
 * 매개변수가 없는 식람다
 * ()=>x*x; (식람다)
 * 
 * 매개변수가 있는 식람다
 * (x)=>x*x;
 * 
 * 매개변수가 없는 문 람다
 * ()=>{ };
 * 
 * 매개변수가 있는 문 람다
 * (x)=>{ };
 * 
 * -----------------
 * 대리자(delegate)
 * C언어에서 함수 포인터와 유사
 * 함수의 대리 역할을 수행 할 수 있도록 구현
 * 함수를 대입하여 사용
 * 대입하는 함수는 대리자의 정의와 리턴값, 매개변수의 타입과 갯수가 맞아야 한다.
 * 대리자는 함수를 대입 할 수 있는 자료형.
 */
public delegate void DoSample();
public delegate int DoIntReturn();
public class Lambda_teach : MonoBehaviour
{
    float elapsed;
    DoSample doSomething;
    DoIntReturn doIntReturn;
    DoSample doBlink;
    // 라이브에서 제공하는 delegate인 Action
    // Action<매개변수의 자료형>
    /*
        Action이란?
    라이브러리에서 제공하는 delegate
    한개의 매개변수와 반환형식이 없는 delegate
    Action<매개변수의 자료형>
     */
    Action<float> act2 = null;
    public void ActionFunction(float _data) { Debug.Log("액션함수 : " + _data); }

    /*
    Func란?
    라이브러리에서 제공하는 delegate
    반드시 반환형식이 존재한다.
    Func<T, TREsult> : T는 매개변수, TResult는 반환형식
    Func<TResult> : 이렇게 하나만 작성하면 매개변수는 생략하고, 반환형식만 존재
     */
    Func<bool> funcB = null; // 리턴이 bool인 함수
    Func<Do, bool> funcC = null;
    // 문제
    // funcB에 대입 할 수 있는 함수를 정의하시오
    public bool AssignFuncB() { return true; }
    //public bool AssignFuncC(Do _do) { return true; }    // 이렇게는 안됨. 엑세스 어렵다고 나옴
    public bool AssignFuncC(DoSample _do) { return true; }

    // 문제 1번 델리게이트 체인
    DoSample doChain;

    private void Start()
    {
        doSomething = Something;

        // 델리게이트에 람다식 넣기
        doSomething += () => { Debug.Log("람다식 작업"); };
        doSomething();  // 실행

        doIntReturn = () => 20 * 20;    // int연산 결과를 반환하기 때문에 대리자 반환형식이 int이어야 한다.
        Debug.Log("두 인트린턴 : " + doIntReturn());

        DoAction(() =>
        {
            Debug.Log("DoAction 함수의 매개변수로 전달");
        });

        DoAction(Something);

        // Action사용
        act2 = ActionFunction;
        act2(100f);

        // Func사용
        funcB = () => false;

        // 1번문제
        doChain += AFunc;
        doChain += BFunc;
        doChain();

        // 3번문제
        elapsed = 1;
        doBlink = AFunc;
    }

    public void Something() { Debug.Log("작업1번"); }

    /**
     * 함수를 매개변수로 전달(일반함수에 매개변수로 델리게이트를 지정 -> 함수의 매개변수가 함수가 됨)
     */
    void DoAction(DoSample _do)
    {
        if (_do != null)
        {
            _do();
        }
    }

    void AFunc()
    {
        Debug.Log("A");
        doBlink = BFunc;
    }
    void BFunc()
    {
        Debug.Log("B");
        doBlink = AFunc;
    }

    private void Update()
    {
        // 문제 3번 - 업데이트에서 한번 실행
        if (doChain != null)
        {
            doChain();
            doChain = null;
        }

        // 문제 4번 - 1초마다 한번씩 A함수와 B함수를 번갈아서 호출하는 프로그램 코드 작성(델리게이트 이용)
        // 1) 업데이트문에서 사용하는 방법
        // 2) invoke함수 이용
        // 3) 코루틴 델리게이트 연결
        // 괜찮은 아이디어인듯.
        elapsed += Time.deltaTime;
        if (elapsed >= 1)
        {
            doBlink();
            elapsed -= 1;
        }
    }
}
