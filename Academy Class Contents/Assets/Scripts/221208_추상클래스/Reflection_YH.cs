using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/**
 * 리플렉션 기능
 * 문자열로 클래스의 인스턴스를 생성
 * 
 * 리플렉션은 클래스 타입, 메서드, 프로퍼티 등의 메타 정보를 런타임 중에 알아내는 기능을 제공한다.
 * 또한 이러한 메타 정보를 얻은 후, 직접 메서드를 호출하거나 프로퍼티를 변경하는 등의 작업도 가능하다.
 * 물론 객체에서 메서드를 직접 호출하는 경우가 더 빠르겠지만, 
 * 어떤 경우는 런타임중에 이런 메타 정보를 이용해서 동적으로 알아낼 필요가 있다.
 * 문자열로 클래스의 인스턴스를 생성
 */
public class NpcInfo
{
    string name;
    public void DoSomthing()
    {
        Debug.Log("NpcInfo실행");
    }
}

public class Reflection_YH : MonoBehaviour
{
    private void Start()
    {
        string className = "NpcInfo";   // 문자열로 클래스 인스턴스 생성 (이게 클래스이름과 동일해야 한다.)
        Assembly creator = Assembly.GetExecutingAssembly();
        NpcInfo obj = creator.CreateInstance(className) as NpcInfo;
        obj.DoSomthing();

        /**
         * Type.GetType() : 메서드는 .NET 어셈블리의 특정 클래스를 사용할 수 있도록 해당 클래스 Type명을 문자열로 받아들여 Type객체를 리턴한다. 
         * 동일한 클래스가 여러 DLL에 존재할 수 있으므로, GetType()에 쓰이는 파라미터는 네임스페이스.클래스, 어셈블리명, 버젼, Culture, PublicKeyToken 등 
         * 여러정보를 사용하여 (이를 AssemblyQualifiedName 이라 부른다) 특정 어셈블리의 클래스 타입을 지정하게 된다.
         */
        // CreateInstance : 지정한 매개 변수와 가장 일치하는 생성자를 사용하여 지정한 유형의 인스턴스를 만듭니다.
        Type customType = Type.GetType("NpcInfo");
        NpcInfo npcInfo = (NpcInfo)Activator.CreateInstance(customType);
        npcInfo.DoSomthing();

        // 메서드를 Get
        MethodInfo method = customType.GetMethod("DoSomthing");
        if (method != null)
        {
            method.Invoke(npcInfo, null);   // 메서드를 실행하기 위해서는, 이렇게 실행 (메서드를 포함한 객체에, 파라미터입력)
        }
    }
}
