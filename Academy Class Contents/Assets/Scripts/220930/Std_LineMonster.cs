using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// ���θ��ʹ�
/// 1. �����Ǹ� �ڵ����� ������ �̵�
/// 
/// </summary>
public class Std_LineMonster : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;

    private void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed);
    }

    public void DestroyMonster()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("tes");
        if (other.gameObject.CompareTag("line"))
        {
            Destroy(gameObject);
        }
    }
}
