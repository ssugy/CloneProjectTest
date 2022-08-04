using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticConst : MonoBehaviour
{
    public int num = 0;
    public int num2 = 0;
    public int num3 = 0;
    public int num4 = 0;
    public int num5 = 0;
    public int num6 = 0;

    // 디자인패턴 - 싱글톤 - 게임메니저, 오디오매니저 => 1개만 필요한것.
    // 싱글톤 => 클래스 자체를 static으로 만든는 것.
    // 어떻게 바뀌냐 => 클래스 내부의 모든 요소가 static화 됨.

    private static StaticConst _unique;
    public static StaticConst s_instance
    {
        get { return _unique; }
    }

    private void Awake()
    {
        _unique = this;
    }

}
