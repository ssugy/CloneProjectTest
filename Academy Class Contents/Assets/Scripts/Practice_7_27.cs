using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 ������ġ�� 3,3,3,
 ��ǥ��ġ�� 10,6,10 �̴�.
 ��ǥ�������� ������ ���ӿ�����Ʈ�� �ٽ� ������ġ�� ���ƿ��� ������ġ�� ���ƿ� 
 ���ӿ�����Ʈ�� �ٽ� ��ǥ��ġ�� �̵��ϴ� ���α׷��ڵ� �ۼ�
 */

public class Practice_7_27 : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    private Vector3 swapos;
    private Vector3 dir;
    private float speed;

    private void Awake()
    {
        // start = new Vector3(3, 3, 3);
        start.Set(3, 3, 3);
        end.Set(10, 6, 10);
        swapos = end;
        dir = end - start;
        speed = 2.5f;
        transform.position = start;     // ���۽� 3,3,3 �� ��ġ���� ����
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(transform.position == end)
        {
            // ��ǥ�������� �����ߴٸ� 
            swapos = start;
        }
        else if(transform.position == start)
        {
            swapos = end;
        }
        transform.position = Vector3.MoveTowards(transform.position, swapos, Time.deltaTime * speed);
        */

        // �Ÿ��� ���⺤�͸� �̿��ؼ� �����ذ�
        float distance = Vector3.Distance(transform.position, swapos);
        if(distance < 0.3f)
        {
            Vector3 tmpdir = end - start;
            if(tmpdir == dir)
            {
                // ���������� ��ǥ�������� �̵��ϴ� ��Ȳ
                swapos = start;
            }
            else
            {
                // ��ǥ�������� ������������ �̵��ϴ� ��Ȳ
                swapos = end;
            }
            dir = -dir;
        }
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }
}
