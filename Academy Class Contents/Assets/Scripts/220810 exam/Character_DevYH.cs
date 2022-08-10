using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_DevYH : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotSpeed = 20;

    // ĳ���� �̵��ϴ� �޼���
    public void MoveCharacter(Vector3 targetPos)
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    // ĳ���� ȸ���ϴ� �޼���
    public void RotCharacter(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * rotSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDir.normalized);
    }
}
