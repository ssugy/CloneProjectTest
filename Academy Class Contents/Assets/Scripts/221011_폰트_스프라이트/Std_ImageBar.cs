using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 3�ʵ��� �پ��� �̹��� ��.
/// </summary>
public class Std_ImageBar : MonoBehaviour
{
    private Image hpBar;
    void Start()
    {
        hpBar = GetComponent<Image>();
        hpBar.fillAmount = 1;
        timeChecker = duration;

        StartCoroutine(DelayedFrame());   // ������ ����� �ִ� ���� �ڵ带 �ִ� ���
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
        Debug.Log(Time.time - timeCnt); //���Ⱑ 3���̸��
    }

    IEnumerator HpBarDown2()
    {
        float timeCnt = Time.time;
        while (hpBar.fillAmount > 0)
        {
            hpBar.fillAmount -= 1 / 600.0f; // FixedUpadte ����ϰ� �̷����ϸ� �׳��� ���� ����.
            yield return new WaitForEndOfFrame();   // fixedupdate�� 0.02�� �ֱ��̴�.
        }
        Debug.Log(Time.time - timeCnt); //���Ⱑ 3���̸��
    }

    IEnumerator HpBarDown3()
    {
        float timeCnt = Time.time;
        while (hpBar.fillAmount > 0)
        {
            hpBar.fillAmount -= (Time.deltaTime)/3f; // �̷����ϸ� �׳��� ���� ����.
            yield return null;   // fixedupdate�� 0.02�� �ֱ��̴�.
        }
        Debug.Log(Time.time - timeCnt); //���Ⱑ 3���̸��
    }

    bool isStart = false;
    float timeTime;
    float timeChecker;
    public float duration = 3;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // �ڷ�ƾ�� �̿��� ��� 
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

        // ����� ��� - �� ����� ���� �ð��� ��Ȯ�ϰ� ����ϰ� ���´�.
        if (isStart)
        {
            // ���� FixedUpdate�̿��� ���
            timeChecker -= Time.deltaTime;
            hpBar.fillAmount = timeChecker / 3;

            if (hpBar.fillAmount <= 0)
            {
                Debug.Log(Time.time - timeTime);    //���Ⱑ 3���̸��
                isStart = false;
            }
        }
    }
}
