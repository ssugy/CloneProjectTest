using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

// 몬스터 손에 이펙트 추가하는 것
public class Std_MonsterFireEffect : MonoBehaviour
{
    private Transform rHandTransform;   
    private void Start()
    {
        FindMonsterTransform(transform, "HR");
        /**
         * find함수의 단점
         * 1. 씬 전체 오브젝트를 검색함
         * 2. 활성화 된 게임 오브젝트만 검색함(비활성화는 검색안함)
         * 3. 동일한 이름의 경우 씬의 위쪽에 있는 오브젝트를 반환한다.(내가 원하는게 나오지 않을 수 있다.)
         */

        GameObject effectPref =  Resources.Load<GameObject>("Effect/FireEffect/" + "FireEffect");
        GameObject effectGo = Instantiate(effectPref, rHandTransform);
        effectGo.transform.localPosition = Vector3.zero;    // 이거없이 인스턴스에서 false처리해도 제대로 적용안되서 이렇게 따로 초기화 함

        
    }

    // 내가 작성한 코드
    private void FindMonsterTransform(Transform tr, string target)
    {
        if (tr.name.Equals(target))
        {
            rHandTransform = tr;
            return;
        }

        for (int i = 0; i < tr.childCount; i++)
        {   
            FindMonsterTransform(tr.GetChild(i).transform, target);
        }
    }

    // 강사님 코드
    private Transform FindChildTransform(string _nodeName, Transform _origin)
    {
        if (_origin.name == _nodeName)
        {
            return _origin;
        }

        for (int i = 0; i < _origin.childCount; i++)
        {
            Transform findTr = FindChildTransform(_nodeName, _origin.GetChild(i));
            if (findTr != null)
                return findTr;
        }
        return null;
    }


    //////////////////애니메이션 이벤트 추가
    public TrailRenderer attackEffect;
    public void StartEffect()
    {
        Debug.Log("이펙트 시작");
        attackEffect.emitting = true;
    }

    private void EndEffect()
    {
        Debug.Log("종료");
        attackEffect.emitting = false;
    }
}
