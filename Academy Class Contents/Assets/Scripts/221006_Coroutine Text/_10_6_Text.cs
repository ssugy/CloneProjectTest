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
        converSation = "마을에서 <color=#FF5502>고블린</color>을 퇴치해주세요";
        scoreText.text = string.Empty;
        char [] arrayObj = converSation.ToCharArray();
        StartCoroutine(DisplayConversation(arrayObj));
        Debug.Log("안녕하세요");
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
