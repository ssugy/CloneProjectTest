using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_6_ShaderFind : MonoBehaviour
{
    // ���̴��� �ǽð� ��ü �ϴ� ���α׷� �ڵ� �ۼ�
    void Start()
    {
        // Renderer��� �̸��� ������Ʈ�� �ڽ��� ���ӿ�����Ʈ���� GetComponent 
        SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if( renderer != null )
        {
            // ���̴� ��ü
            renderer.material.shader = Shader.Find("Mobile/Diffuse");
        }
        List<SkinnedMeshRenderer> resultList = new List<SkinnedMeshRenderer>();
        GetComponentsInChildren<SkinnedMeshRenderer>(resultList);
        foreach(SkinnedMeshRenderer one in resultList)
        {
            Debug.Log(one);
        }
        // �θ��� ���ӿ�����Ʈ���� ������Ʈ�� Get
        // SkinnedMeshRenderer renderer = GetComponentInParent<SkinnedMeshRenderer>();
    }
    void Update()
    {
        
    }
}
