using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _10_6_Text : MonoBehaviour
{
    public Text scoreText;
    string converSation;
    void Start()
    {
        converSation = "�������� <color=#FF5502>���</color>�� ��ġ���ּ���";
        scoreText.text = string.Empty;
        char [] arrayObj = converSation.ToCharArray();
        StartCoroutine(DisplayConversation(arrayObj));
        Debug.Log("�ȳ��ϼ���");
    }
    IEnumerator DisplayConversation(char [] _arrObj)
    {
        for (int i = 0; i < _arrObj.Length; i++)
        {
            scoreText.text += _arrObj[i];
            yield return new WaitForSeconds(0.2f);
        }
    }
    void Update()
    {
        
    }
}
