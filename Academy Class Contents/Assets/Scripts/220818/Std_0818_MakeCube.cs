using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1. Ray�� �̿��� ���� ���� ���
 * 2. ���� ���� �� 10���� ť��(������)�� �ε��ϰ� �ٴ������� ���̿� ������� ť�긦 ��ġ�ϴ� ���α׷� �ڵ� �ۼ�.
 * �� ť��� �ٴ��� ������ ��� �� ����.
 * ť�꿡�� Monster��� ��ũ��Ʈ�� ������ �߰��Ѵ�.
 */
public class Std_0818_MakeCube : MonoBehaviour
{

    private void Start()
    {
        MakeCube();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                print("Found an object - distance : " + hit.distance);
            }
        }
    }

    private void MakeCube()
    {
        GameObject go = Resources.Load<GameObject>("Character/Cube");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(go, CalcSpawnPos(), Quaternion.identity);
        }
    }

    public Transform[] spawnTransform;  // ������ �� �� 0���� ���� �ϴ�, 1���� ���� ���
    
    // ť�갡 ���� �� ��ġ Ȯ��
    private Vector3 CalcSpawnPos()
    {
        // 1. ���� ������ ���� - ����� ������Ʈ 2���� ���� -> ������������ ������ ��ǥ�� ����
        Vector3 spawnPos = new Vector3(Random.Range(spawnTransform[0].position.x, spawnTransform[1].position.x)
                                        , 100
                                        , Random.Range(spawnTransform[0].position.z, spawnTransform[1].position.z));

        // 2. ������ ��ǥ���� -Vector3.up������ ����ĳ��Ʈ�� ���� hit�Ǵ� ��ġ�� ��ȯ -> ���⼭ cube������ �ٽ� ���� ������ �ϱ�.
        //�׷��� �׷����ϸ�, ť�곢�� ��ĥ �����ִ�. �׷��� ��Ȯ�Ѱ�, �� ť���� ��ġ�� �����ؼ�  �Ÿ��� Ȯ���� ��, ������ġ�� �ٽ� ���� ������ �ؾߵȴ�.
        RaycastHit hit;
        Physics.Raycast(spawnPos, -Vector3.up, out hit);
        
        return hit.point;   // �ٴ��� ������ ����� �ʴ´ٰ� �ϴ�, ����ó�� ���ϱ���
    }

    
}
