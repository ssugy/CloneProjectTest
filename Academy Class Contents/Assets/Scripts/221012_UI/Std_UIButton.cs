using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Std_UIButton : MonoBehaviour
{
    public Button uiButton;
    public Animator btnAnim;
    private void Start()
    {
        Debug.Log("test");
        uiButton.onClick.AddListener(OKButtonClick);    // �̷��� ���� ��ư�� ����ؼ� ��� �� �� �ִ�.(��������Ʈ)
        //uiButton.onClick.AddListener(OKButtonClick);
        //uiButton.onClick.RemoveListener(OKButtonClick); // ���� ����
        
    }

    public void OKButtonClick()
    {
        Debug.Log("OKButton Click");
        btnAnim.SetTrigger("BtnScale");
    }

}
