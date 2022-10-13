using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// T�� Ŭ������
/// where T��� �ϴ� ���� ���������� �ɰڴٴ� �ǹ�
/// �׷��� �� ���������� 2���� �ɾ��µ� class��� �������ǰ� new()��� ��������
/// class����������, T�� ���� �����̾�� �Ѵ�.
/// new()�� �Ű������� ���� �����ڶ�� �ǹ��̴�.
/// </summary>
/// <typeparam name="T">Ŭ������</typeparam>
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

    // �����ڿ��� �����ϰų� �� �ʿ����. �����ڸ� �׳� �����δ� �뵵
    // �̰� protected�� �ؾ��� ������ ������ ����.
    // ���Ⱑ �Ű������� ����ߵȴ�. �װ� new()�� �����̴�.
    protected SingleTon()
    {
        
    }
}
