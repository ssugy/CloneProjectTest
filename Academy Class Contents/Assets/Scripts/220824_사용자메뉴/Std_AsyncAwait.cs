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
            await Task.Delay(5000, cts.Token); // await�� �Ϲ������� 2������ ���·� ���. Delay�� �ٸ�await�� ��ٸ���,
            Debug.Log(cnt--);
            await MySecond();
            Debug.Log(cnt--);
        }
    }

    async Task MySecond()
    {
        Debug.Log("�ι�° �Լ� ����");
        await Task.Delay(2000);
        Debug.Log("�ι�° �Լ� ����");
    }

    /**
     * Async-await�� ���߱� ���ؼ��� ��ū�� �ʿ��մϴ�. �ش� ��ū�� ������ �ִ� Task�� ���ÿ� ���� �� �ֽ��ϴ�.
     * ���� �½�ũ �߰��� �̰� �ϸ�, �ٷ� ��������,
     * �ٸ� �½�ũ �����߿� ���߸� �ش� ��ū�� ������ ���� ����� �� �������ϴ�.
     */
    CancellationTokenSource cts = new CancellationTokenSource();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Async ���߱�");
            cts.Cancel();   //�̰� ���� ������ �ߴµ�, �̰� �۾� ��Ҹ� �˸������� �����Դϴ�.
            Debug.LogError("test");
        }
    }
}
