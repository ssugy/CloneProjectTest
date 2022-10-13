using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// T는 클래스명
/// where T라고 하는 것은 제약조건을 걸겠다는 의미
/// 그래서 그 제약조건은 2개를 걸었는데 class라는 제약조건과 new()라는 제약조건
/// class제약조건은, T가 참조 형식이어야 한다.
/// new()는 매개변수가 없는 생성자라는 의미이다.
/// </summary>
/// <typeparam name="T">클래스명</typeparam>
public class SingleTon<T> where T: class, new()
{
    private static T inst;
    public static T instance { 
        get { 
            if (inst == null)
                inst = new T();
            return inst; 
        } 
    }

    // 생성자에서 지정하거나 할 필요없음. 생성자만 그냥 만들어두는 용도
    // 이거 protected로 해야지 에러가 생기지 않음.
    // 여기가 매개변수가 없어야된다. 그게 new()의 조건이다.
    protected SingleTon()
    {
        
    }
}
