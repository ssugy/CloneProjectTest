using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// 플레이어가
/// </summary>
public class Std_PlayerWithStick : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (new Vector3(Std_StickController.figuredDir.x, 0, Std_StickController.figuredDir.y) * Time.deltaTime * moveSpeed);
    }
}
