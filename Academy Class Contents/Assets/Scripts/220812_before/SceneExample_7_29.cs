using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExample_7_29 : MonoBehaviour
{
    float moveSpeed;
    void Awake()
    {
        moveSpeed = 2.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(x != 0)
            Debug.Log("수평축입력값 = " + x);
        if(y != 0)
            Debug.Log("수직축입력값 = " + y);
        // 위의 x, y값을 이용해서 게임오브젝트를 이동시키시오.
        // y축의 입력값을 z축 이동에 적용하시오.
        Vector3 tmp = transform.position;
        tmp.x += x * Time.deltaTime * moveSpeed;
        tmp.z += y * Time.deltaTime * moveSpeed;
        transform.position = tmp;
        // 
        // 씬뷰에 선을 그릴 수 있다.
        Debug.DrawLine(transform.position, new Vector3(10,10,10), Color.green);
    }
}
