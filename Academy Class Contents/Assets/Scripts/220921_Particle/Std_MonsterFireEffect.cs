using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

// ���� �տ� ����Ʈ �߰��ϴ� ��
public class Std_MonsterFireEffect : MonoBehaviour
{
    private Transform rHandTransform;   
    private void Start()
    {
        FindMonsterTransform(transform, "HR");
        /**
         * find�Լ��� ����
         * 1. �� ��ü ������Ʈ�� �˻���
         * 2. Ȱ��ȭ �� ���� ������Ʈ�� �˻���(��Ȱ��ȭ�� �˻�����)
         * 3. ������ �̸��� ��� ���� ���ʿ� �ִ� ������Ʈ�� ��ȯ�Ѵ�.(���� ���ϴ°� ������ ���� �� �ִ�.)
         */

        GameObject effectPref =  Resources.Load<GameObject>("Effect/FireEffect/" + "FireEffect");
        GameObject effectGo = Instantiate(effectPref, rHandTransform);
        effectGo.transform.localPosition = Vector3.zero;    // �̰ž��� �ν��Ͻ����� falseó���ص� ����� ����ȵǼ� �̷��� ���� �ʱ�ȭ ��

        
    }

    // ���� �ۼ��� �ڵ�
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

    // ����� �ڵ�
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


    //////////////////�ִϸ��̼� �̺�Ʈ �߰�
    public TrailRenderer attackEffect;
    public void StartEffect()
    {
        Debug.Log("����Ʈ ����");
        attackEffect.emitting = true;
    }

    private void EndEffect()
    {
        Debug.Log("����");
        attackEffect.emitting = false;
    }
}
