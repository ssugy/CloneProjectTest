using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
1.	만약 내가 물약을 마시면, 1초마다 10씩의 체력을 올리기 위해서는 어떤 방법으로 코드를 작성해야 될까?
 A.	1초에 10이니까, update내부에 timeCnt변수를 설정해서 1초마다 10씩 증가
 B.	timeCnt변수 사용하는 것은 별로니까 Time.time을 이용해서 1초에 한번씩 지정
 C.	(여기서부터) 코루틴 사용해서 1초에 한번씩 딜레이 주기.
 D.	(추가방법) InvokeRepeat를 이용한 방법.
 E.	(추가방법) Async Await방법을 이용
 i.	닷넷프레임워크 4.x에 추가된 내용
 F.	(문제) 오브젝트의 색상을 받아서 원하는 색상으로 천천히 변하게 만들기.
 */
public class Std_Coroutine : MonoBehaviour
{
    Coroutine myCo;

    private void Start()
    {
        StartCoroutine("MyCoroutine");  // 정지 가능
        //StartCoroutine(MyCoroutine());  // 일반정지는 안됨, stopAll로 정지 가능
        //myCo = StartCoroutine(MyCoroutine());   //파라미터가 있는 코루틴은 이런식으로 구분해서 정지해줘야된다.
    }

    IEnumerator MyCoroutine()
    {
        int n = 0;
        while (true)
        {
            n++;
            //내가 시작 할 일
            Debug.Log("최초 시작" + n);

            yield return new WaitForSeconds(2);

            //딜레이 후 할 일
            Debug.Log("딜레이 후 할 일" + n);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("정지 신호");
            StopCoroutine("MyCoroutine");
            //StopCoroutine(MyCoroutine()); // 이걸로 안됨
            //StopAllCoroutines();
            //StopCoroutine(myCo);    // 이렇게 하면 파라미터있는 코루틴도 정지 가능하다.
        }
    }
}
