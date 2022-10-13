using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class _10_12_UIManager : MonoBehaviour
{
    public Button uiButton;
    public Animator uiButtonAni;
    void Start()
    {
        // UI의 크기
        Vector2 size = uiButton.gameObject.GetComponent<RectTransform>().sizeDelta;
        // 또는
        float width = uiButton.gameObject.GetComponent<RectTransform>().rect.width;
        float height = uiButton.gameObject.GetComponent<RectTransform>().rect.height;
        uiButton.onClick.AddListener(OkButtonClickTypeA);
    }
    public void OkButtonClickTypeA()
    {
        Debug.Log("OkButtonClickTypeA");
        uiButton.onClick.RemoveListener(OkButtonClickTypeA);
        uiButton.onClick.AddListener(OkButtonClickTypeB);
        uiButtonAni.SetTrigger("ButtonScale");
    }
    public void OkButtonClickTypeB()
    {
        Debug.Log("OkButtonClickTypeB");
        uiButton.onClick.RemoveListener(OkButtonClickTypeB);
        uiButton.onClick.AddListener(OkButtonClickTypeA);
        uiButtonAni.SetTrigger("ButtonNormal");
    }
    void Update()
    {
        
    }
}
