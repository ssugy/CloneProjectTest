using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1. 정점의 갯수 구하기
 */
public class Std220804_MeshInfo : MonoBehaviour
{
    // Cube에 추가되어 있는 Mesh 정보에 접근
    MeshFilter meshFilter;
    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        for (int i = 0; i < meshFilter.mesh.vertexCount; i++)
        {
            // 정점 좌표는 자신의 중앙점을 기준으로 좌표
            //print(meshFilter.mesh.vertices[i]);
            // 정점의 월드좌표를 구하기 위해서는, 자신의 월드좌표를 더해준다
            print($"{i}번째 좌표 :  {transform.position + meshFilter.mesh.vertices[i]}");
            // 월드 좌표를 구하기 위한 함수 사용
            Vector3 worldPos = transform.TransformPoint(meshFilter.mesh.vertices[i]);
            print($"{i}번째 좌표(변환공식) : {worldPos}");
        }
    }
}
