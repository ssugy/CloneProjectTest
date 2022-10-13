using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 3초동안 줄어드는 이미지 바.
/// </summary>
public class Std_ImageBar : MonoBehaviour
{
    private Image hpBar;
    void Start()
    {
        hpBar = GetComponent<Image>();
        hpBar.fillAmount = 1;
        timeChecker = duration;

        StartCoroutine(DelayedFrame());   // 프레임 드랍이 있는 방해 코드를 넣는 경우
    }

    IEnumerator DelayedFrame()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(100000, 200000); i++)
            {
                Mathf.Pow(Random.Range(0, 10000), 2);
            }
            yield return null;
            //yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator HpBarDown()
    {
        float timeCnt = Time.time;
        while (hpBar.fillAmount > 0)
        {
            hpBar.fillAmount -= 1/60.0f;
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log(Time.time - timeCnt); //여기가 3초이면됨
    }

    IEnumerator HpBarDown2()
    {
        float timeCnt = Time.time;
        while (hpBar.fillAmount > 0)
        {
            hpBar.fillAmount -= 1 / 600.0f; // FixedUpadte 사용하고 이렇게하면 그나마 오차 줄임.
            yield return new WaitForEndOfFrame();   // fixedupdate는 0.02초 주기이다.
        }
        Debug.Log(Time.time - timeCnt); //여기가 3초이면됨
    }

    IEnumerator HpBarDown3()
    {
        float timeCnt = Time.time;
        while (hpBar.fillAmount > 0)
        {
            hpBar.fillAmount -= (Time.deltaTime)/3f; // 이렇게하면 그나마 오차 줄임.
            yield return null;   // fixedupdate는 0.02초 주기이다.
        }
        Debug.Log(Time.time - timeCnt); //여기가 3초이면됨
    }

    bool isStart = false;
    float timeTime;
    float timeChecker;
    public float duration = 3;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 코루틴을 이용한 방법 
            StartCoroutine(HpBarDown());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isStart = true;
            timeTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(HpBarDown2());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(HpBarDown3());
        }

        // 강사님 방법 - 이 방법이 가장 시간이 정확하고 깔끔하게 나온다.
        if (isStart)
        {
            // 직접 FixedUpdate이용한 방법
            timeChecker -= Time.deltaTime;
            hpBar.fillAmount = timeChecker / 3;

            if (hpBar.fillAmount <= 0)
            {
                Debug.Log(Time.time - timeTime);    //여기가 3초이면됨
                isStart = false;
            }
        }
    }
}
