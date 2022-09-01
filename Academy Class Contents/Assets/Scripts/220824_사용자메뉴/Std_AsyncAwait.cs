using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Std_AsyncAwait : MonoBehaviour
{
    void Start()
    {
        MyAsync(10);
    }

    async void MyAsync(int cnt)
    {
        while (true)
        {
            Debug.Log(cnt--);
            await Task.Delay(5000, cts.Token); // await는 일반적으로 2가지의 형태로 사용. Delay와 다른await를 기다리기,
            Debug.Log(cnt--);
            await MySecond();
            Debug.Log(cnt--);
        }
    }

    async Task MySecond()
    {
        Debug.Log("두번째 함수 진입");
        await Task.Delay(2000);
        Debug.Log("두번째 함수 종료");
    }

    /**
     * Async-await를 멈추기 위해서는 토큰이 필요합니다. 해당 토큰을 가지고 있는 Task를 동시에 멈출 수 있습니다.
     * 만약 태스크 중간에 이걸 하면, 바로 멈춰지고,
     * 다른 태스크 진행중에 멈추면 해당 토큰을 만날때 까지 진행된 뒤 멈춰집니다.
     */
    CancellationTokenSource cts = new CancellationTokenSource();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Async 멈추기");
            cts.Cancel();   //이거 쓰면 에러가 뜨는데, 이건 작업 취소를 알리기위한 목적입니다.
            Debug.LogError("test");
        }
    }
}
