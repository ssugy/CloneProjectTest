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

    // ���������� - �̱��� - ���Ӹ޴���, ������Ŵ��� => 1���� �ʿ��Ѱ�.
    // �̱��� => Ŭ���� ��ü�� static���� ����� ��.
    // ��� �ٲ�� => Ŭ���� ������ ��� ��Ұ� staticȭ ��.

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
