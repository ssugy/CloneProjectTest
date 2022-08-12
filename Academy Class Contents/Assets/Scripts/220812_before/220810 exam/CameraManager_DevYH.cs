using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager_DevYH : MonoBehaviour
{
    [SerializeField] private Vector3 offsetPos = new Vector3(0, 5, -10);
    [SerializeField] private Vector3 offsetRot = new Vector3(15, 0, 0);

    private GameObject targetPlayer;
    public GameObject TargetPlayer
    {
        set { targetPlayer = value; }
    }

    // ī�޶� ��ġ, ȸ�� �ʱ�ȭ
    public void InitCameraPosRot()
    {
        transform.position = targetPlayer.transform.position + offsetPos;
        transform.rotation = targetPlayer.transform.rotation * Quaternion.Euler(offsetRot);
    }

    // ī�޶�� Ÿ���� �i��
    public void TracePlayer()
    {
        // �����ϰ� �̵�
        //transform.position = targetPlayer.transform.position + offsetPos; 
        
        // �ε巴�� �̵�
        transform.position = Vector3.Slerp(transform.position ,targetPlayer.transform.position + offsetPos, Time.deltaTime * 5f);
    }
}
