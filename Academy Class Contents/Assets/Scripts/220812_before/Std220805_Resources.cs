using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ���ҽ� �������� ������ �����ͼ� ���̶�Ű â�� �����ִ� ��
 * [����]
 * Character ������ �ִ� �������� �ε��Ͽ� ����Ʈ�� ����
 * ����Ʈ���� ���ϴ� ���ӿ�����Ʈ�� �˻��Ͽ� �ν��Ͻ��� �����ϴ� �Լ��� ����
 * (����) ���ҽ��� �����ϰ� �ִ� ������ Ŭ������ �����ؾ� �Ѵ�.(�̱���� ���� Ŭ���� �̿�)
 * 
 * ����Ƽ ������ �ڷ����� ���� �� �� �ִ�.
 * 1. �ؽ�Ʈ ��� ���� : TextAsset
 * 2. �ؽ�ó : Texture2D
 * 3. ��������Ʈ : Sprite
 * 4. ������ : GameObject
 */
public class Std220805_Resources : MonoBehaviour
{
    private void Start()
    {
        // �ε�� �޸𸮿� �÷��� ���� �ǹ�
        // ȭ�鿡 �������� ���� �ƴϴ�.
        GameObject tmp = Resources.Load("Character/Meshtint Free Knight") as GameObject;
        // ���� �ν��Ͻ� ����
        GameObject obj = GameObject.Instantiate(tmp, new Vector3(3, 3, 3), Quaternion.identity);
        obj.name = "Meshtint Free Knight";

        // Weapon������ �����ϴ� ��� ������ �ε�
        GameObject[] weapons = Resources.LoadAll<GameObject>("Weapon/");
        // �ε��� ���ӿ�����Ʈ�� �ν��Ͻ��� ���� ����
        foreach (GameObject item in weapons)
        {
            Instantiate(item, new Vector3(1, 1, 1), Quaternion.identity);
            
        }

if (Input.GetKey(KeyCode.UpArrow))
{
// �̵����� ����
}
    }
}
