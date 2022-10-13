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
        uiButton.onClick.AddListener(OKButtonClick);    // 이렇게 직접 버튼을 등록해서 사용 할 수 있다.(델리게이트)
        //uiButton.onClick.AddListener(OKButtonClick);
        //uiButton.onClick.RemoveListener(OKButtonClick); // 삭제 가능
        
    }

    public void OKButtonClick()
    {
        Debug.Log("OKButton Click");
        btnAnim.SetTrigger("BtnScale");
    }

}
