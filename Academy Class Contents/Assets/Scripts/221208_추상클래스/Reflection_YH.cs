using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/**
 * ���÷��� ���
 * ���ڿ��� Ŭ������ �ν��Ͻ��� ����
 * 
 * ���÷����� Ŭ���� Ÿ��, �޼���, ������Ƽ ���� ��Ÿ ������ ��Ÿ�� �߿� �˾Ƴ��� ����� �����Ѵ�.
 * ���� �̷��� ��Ÿ ������ ���� ��, ���� �޼��带 ȣ���ϰų� ������Ƽ�� �����ϴ� ���� �۾��� �����ϴ�.
 * ���� ��ü���� �޼��带 ���� ȣ���ϴ� ��찡 �� ����������, 
 * � ���� ��Ÿ���߿� �̷� ��Ÿ ������ �̿��ؼ� �������� �˾Ƴ� �ʿ䰡 �ִ�.
 * ���ڿ��� Ŭ������ �ν��Ͻ��� ����
 */
public class NpcInfo
{
    string name;
    public void DoSomthing()
    {
        Debug.Log("NpcInfo����");
    }
}

public class Reflection_YH : MonoBehaviour
{
    private void Start()
    {
        string className = "NpcInfo";   // ���ڿ��� Ŭ���� �ν��Ͻ� ���� (�̰� Ŭ�����̸��� �����ؾ� �Ѵ�.)
        Assembly creator = Assembly.GetExecutingAssembly();
        NpcInfo obj = creator.CreateInstance(className) as NpcInfo;
        obj.DoSomthing();

        /**
         * Type.GetType() : �޼���� .NET ������� Ư�� Ŭ������ ����� �� �ֵ��� �ش� Ŭ���� Type���� ���ڿ��� �޾Ƶ鿩 Type��ü�� �����Ѵ�. 
         * ������ Ŭ������ ���� DLL�� ������ �� �����Ƿ�, GetType()�� ���̴� �Ķ���ʹ� ���ӽ����̽�.Ŭ����, �������, ����, Culture, PublicKeyToken �� 
         * ���������� ����Ͽ� (�̸� AssemblyQualifiedName �̶� �θ���) Ư�� ������� Ŭ���� Ÿ���� �����ϰ� �ȴ�.
         */
        // CreateInstance : ������ �Ű� ������ ���� ��ġ�ϴ� �����ڸ� ����Ͽ� ������ ������ �ν��Ͻ��� ����ϴ�.
        Type customType = Type.GetType("NpcInfo");
        NpcInfo npcInfo = (NpcInfo)Activator.CreateInstance(customType);
        npcInfo.DoSomthing();

        // �޼��带 Get
        MethodInfo method = customType.GetMethod("DoSomthing");
        if (method != null)
        {
            method.Invoke(npcInfo, null);   // �޼��带 �����ϱ� ���ؼ���, �̷��� ���� (�޼��带 ������ ��ü��, �Ķ�����Է�)
        }
    }
}
