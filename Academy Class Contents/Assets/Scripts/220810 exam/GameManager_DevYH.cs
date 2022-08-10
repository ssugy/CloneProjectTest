using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 1. ���۽� ���ҽ��ε��Ͽ� ȭ�鿡 ��ġ ( �����̿� ������� ���� ��ġ ) - GameManager.cs
 * 2. ���콺 ��ŷ(Picking)�� ���� ĳ���� �̵� ���� - GameManager.cs // Character.cs
 * 3. ���콺�� ĳ���� ���ý� �ֺܼ信 ĳ���� �̸� ��� - GameManager.cs
 * 4. ĳ���Ͱ� �̵��� ī�޶�� �ʱ��� �Ÿ��� ������ ä�� ĳ���͸� ���� �̵��Ѵ�. �� ,ĳ������ ȸ���� ī�޶� ������� �ʴ´�.
 */
public class GameManager_DevYH : MonoBehaviour
{
    // 1. �޸� ������ ���� ���ӿ�����Ʈ ���� - Instantiate�� ������ �� ���� �ִٴ� Ȯ�强 ����
    GameObject character;

    // 2. ���콺 ��ŷ�� ���� ĳ���� �̵� ������ ���� ����
    Character_DevYH playerCharacter;
    CameraManager_DevYH cameraManager;
    BoxCollider boxCollider;
    Vector3 targetPos;    // ������ ��ġ
    
    void Start()
    {
        // 1. ���۽� ���ҽ��ε��Ͽ� ȭ�鿡 ��ġ ( �����̿� ������� ���� ��ġ )
        character = Instantiate(Resources.Load<GameObject>("TrollGiant") , Vector3.zero, Quaternion.identity);

        // �ʱⰪ ����
        playerCharacter = character.AddComponent<Character_DevYH>();
        boxCollider = character.AddComponent<BoxCollider>();  // player���� �´� �ݶ��̴� �߰�.(üũ�� ���� �ݶ��̴� �߰�)
        boxCollider.size = new Vector3(2, 2, 1);              // ĳ���Ϳ� �´� �ݶ��̴� ����
        boxCollider.center = new Vector3(0, 1, 0);
        character.layer = 6;    // player ���̾� �ο�
        character.tag = "Player";
        character.name = "���";
        
        // 4. ī�޶� ������Ʈ �߰�
        cameraManager = Camera.main.gameObject.AddComponent<CameraManager_DevYH>();
        cameraManager.TargetPlayer = character;
        cameraManager.InitCameraPosRot();    // ī�޶� ��ġ/ȸ�� �ʱ�ȭ
    }

    void Update()
    {
        // 2.���콺 ��ŷ(Picking)�� ���� ĳ���� �̵� ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                // ���̾ �ƴ� �±׸� �̿��� �и�. �̷��� �ϸ� ĳ���͸� Ŭ���ϸ� �̸��� ��µǰ� �̵��� ���� �ʽ��ϴ�.
                // 3. ���콺�� ĳ���� ���ý� �ֺܼ信 ĳ���� �̸� ���
                if (hitInfo.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("ĳ���� �̸� : " + hitInfo.collider.gameObject.name);
                }
                else
                {
                    targetPos = hitInfo.point;
                }
            }
        }

        // 2.���콺 ��ŷ(Picking)�� ���� ĳ���� �̵� ����
        playerCharacter.MoveCharacter(targetPos);
        playerCharacter.RotCharacter(targetPos);    // ȸ������

        // 4. �÷��̾� �̵��� ���� ī�޶� ���� �̵�
        cameraManager.TracePlayer();
    }
}
