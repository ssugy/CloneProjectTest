using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1. ������ ���� ���ϱ�
 */
public class Std220804_MeshInfo : MonoBehaviour
{
    // Cube�� �߰��Ǿ� �ִ� Mesh ������ ����
    MeshFilter meshFilter;
    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        for (int i = 0; i < meshFilter.mesh.vertexCount; i++)
        {
            // ���� ��ǥ�� �ڽ��� �߾����� �������� ��ǥ
            //print(meshFilter.mesh.vertices[i]);
            // ������ ������ǥ�� ���ϱ� ���ؼ���, �ڽ��� ������ǥ�� �����ش�
            print($"{i}��° ��ǥ :  {transform.position + meshFilter.mesh.vertices[i]}");
            // ���� ��ǥ�� ���ϱ� ���� �Լ� ���
            Vector3 worldPos = transform.TransformPoint(meshFilter.mesh.vertices[i]);
            print($"{i}��° ��ǥ(��ȯ����) : {worldPos}");
        }
    }
}
