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

    // 카메라 위치, 회전 초기화
    public void InitCameraPosRot()
    {
        transform.position = targetPlayer.transform.position + offsetPos;
        transform.rotation = targetPlayer.transform.rotation * Quaternion.Euler(offsetRot);
    }

    // 카메라로 타겟을 쫒기
    public void TracePlayer()
    {
        // 딱딱하게 이동
        //transform.position = targetPlayer.transform.position + offsetPos; 
        
        // 부드럽게 이동
        transform.position = Vector3.Slerp(transform.position ,targetPlayer.transform.position + offsetPos, Time.deltaTime * 5f);
    }
}
