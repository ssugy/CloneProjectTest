using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 시작위치는 3,3,3,
 목표위치는 10,6,10 이다.
 목표지점까지 도달한 게임오브젝트는 다시 시작위치로 돌아오고 시작위치로 돌아온 
 게임오브젝트는 다시 목표위치로 이동하는 프로그램코드 작성
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
        transform.position = start;     // 시작시 3,3,3 의 위치에서 시작
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
            // 목표지점까지 도달했다면 
            swapos = start;
        }
        else if(transform.position == start)
        {
            swapos = end;
        }
        transform.position = Vector3.MoveTowards(transform.position, swapos, Time.deltaTime * speed);
        */

        // 거리와 방향벡터를 이용해서 문제해결
        float distance = Vector3.Distance(transform.position, swapos);
        if(distance < 0.3f)
        {
            Vector3 tmpdir = end - start;
            if(tmpdir == dir)
            {
                // 시작점에서 목표지점으로 이동하는 상황
                swapos = start;
            }
            else
            {
                // 목표지점에서 시작지점으로 이동하는 상황
                swapos = end;
            }
            dir = -dir;
        }
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }
}
