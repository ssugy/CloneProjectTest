using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample_7_28 : MonoBehaviour
{
    float moveSpeed;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            //Debug.Log("space key was pressed");
            transform.position = new Vector3(10, 10, 10);
        }
        // �ּ��� �� Ȱ���ϼ���.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            //Debug.Log("space key was pressed");
        }
        //MoveTypeA();
        MoveTypeB();
    }
    void MoveTypeA()
    {
        // GetKey�Լ� ���
        // Arrow�� ����Ű�̴�.
        float dx = Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // GetKey�Լ��� Ű�� ������ �ִ� ������ �ǹ�
            transform.Translate(-dx, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(dx, 0, 0);
        }
        if( Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, dx, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -dx, 0);
        }
    }
    // transform.position ���� ���� ���
    void MoveTypeB()
    {
        float dx = 0f;
        float dy = 0f;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            dx = -1f;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            dx = 1f;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            dy = 1f;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            dy = -1;
        }
        Vector3 tmp = transform.position;
        tmp.x += dx * Time.deltaTime * moveSpeed;
        tmp.y += dy * Time.deltaTime * moveSpeed;
        transform.position = tmp;
        float distance = Vector3.Distance(transform.position, item.transform.position);
        if(distance < 1.0f)
        {
            if(item.activeSelf == true)    // activeSelf ������Ƽ�� Ȱ��ȭ ��Ȱ��ȭ ����
            {
                Debug.Log("������ ȹ��");
            }
            item.SetActive(false);  // ���ӿ�����Ʈ Ȱ��ȭ ��Ȱ��ȭ �Լ��� ���ӿ�����Ʈ�Ǹɹ��Լ��� SetActive �Լ� �̴�.
        }
    }
}
